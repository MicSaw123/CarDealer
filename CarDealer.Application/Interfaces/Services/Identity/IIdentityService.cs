using CarDealer.Application.DataTransferObjects.Dtos.Identity;

namespace CarDealer.Application.Interfaces.Services.Identity
{
    public interface IIdentityService
    {

        Task<RequestResult> Register(RegisterDto regiserDto);

        Task<RequestResult<LoginResponseDto>> Login(LoginDto loginDto);

        Task<RequestResult<UserInfoDto>> GetUserInfoById(int id);

        Task<RequestResult> UpdateAccountDetails(UserInfoDto userInfoDto, CancellationToken cancellation);
    }
}
