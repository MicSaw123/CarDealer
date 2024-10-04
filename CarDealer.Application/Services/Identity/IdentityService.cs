using AutoMapper;
using CarDealer.Application.DataTransferObjects.Dtos.Identity;
using CarDealer.Application.Interfaces.Database;
using CarDealer.Application.Interfaces.Services.Identity;
using CarDealer.Domain.Entities.Identity;
using CarDealer.Domain.Errors;
using CarDealer.Domain.Errors.IdentityErrors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public IdentityService(UserManager<CarDealerUser> userManager,
            RoleManager<CarDealerRole> roleManager,
            IConfiguration configuration,
            IDbContext context,
            IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _context = context;
            _mapper = mapper;
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
                CityId = registerDto.CityId,
                AccountTypeId = registerDto.AccountTypeId
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                return Error.ErrorUnknown;
            }

            return RequestResult.Success();
        }

        public async Task<RequestResult<UserInfoDto>> GetUserInfoById(int id)
        {
            var user = _context.Set<CarDealerUser>().FirstOrDefaultAsync(x => x.Id == id).Result;
            var userDto = _mapper.Map<UserInfoDto>(user);
            if (user is null)
            {
                return RequestResult<UserInfoDto>.Failure(Error.ErrorUnknown);
            }
            return RequestResult<UserInfoDto>.Success(userDto);
        }

        public async Task<RequestResult> UpdateAccountDetails(UserInfoDto userInfoDto, CancellationToken cancellation = default)
        {
            var userInfo = _mapper.Map<CarDealerUser>(userInfoDto);
            var user = await _context.Set<CarDealerUser>().FirstOrDefaultAsync(x => x.Id == userInfoDto.Id);
            user.PhoneNumber = userInfo.PhoneNumber;
            user.UserName = userInfo.UserName;
            user.Email = userInfo.Email;
            user.NormalizedEmail = userInfoDto.Email.ToUpper();
            user.NormalizedUserName = userInfoDto.UserName.ToUpper();
            await _userManager.ChangePasswordAsync(user, userInfoDto.CurrentPassword, userInfoDto.UpdatedPassword);
            try
            {
                await _context.SaveChangesAsync(cancellation);

            }
            catch (Exception ex)
            {
                throw;
            }
            return RequestResult.Success();
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.UtcNow.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
