using CarDealer.Application.DataTransferObjects.Dtos.Identity;
using CarDealer.Application.Interfaces.Services.Identity;
using CarDealer.Domain.Entities.Identity;
using CarDealer.Domain.Errors;
using CarDealer.Domain.Errors.IdentityErrors;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CarDealer.Application.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<CarDealerUser> _userManager;
        private readonly RoleManager<CarDealerRole> _roleManager;
        private readonly IConfiguration _configuration;

        public IdentityService(UserManager<CarDealerUser> userManager,
            RoleManager<CarDealerRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        public async Task<RequestResult<LoginResponseDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == default)
            {
                return RequestResult<LoginResponseDto>.Failure(IdentityErrors.UserDoesNotExist);
            }

            var passwordIsCorrect = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!passwordIsCorrect)
            {
                return RequestResult<LoginResponseDto>.Failure(IdentityErrors.WrongPassword);

            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                 {
                     new Claim(ClaimTypes.Name, user.Email),
                     new Claim("id", user.Id.ToString()),
                     new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                 };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GetToken(authClaims);

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            var loginResponse = new LoginResponseDto
            {
                Token = tokenString
            };
            return RequestResult<LoginResponseDto>.Success(loginResponse);
        }



        public async Task<RequestResult> Register(RegisterDto registerDto)
        {
            var userExists = await _userManager.FindByNameAsync(registerDto.Username);
            var emailExists = await _userManager.FindByEmailAsync(registerDto.Email);
            if (userExists != null)
            {
                return IdentityErrors.UsernameAlreadyTaken;
            }
            if (emailExists != null)
            {
                return IdentityErrors.EmailAlreadyTaken;
            }

            CarDealerUser user = new()
            {
                Email = registerDto.Email,
                UserName = registerDto.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
                PhoneNumber = registerDto.PhoneNumber,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return Error.ErrorUnknown;
            }

            return RequestResult.Success();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
