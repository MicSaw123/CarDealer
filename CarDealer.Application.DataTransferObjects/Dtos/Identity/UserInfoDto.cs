using CarDealer.Domain.Entities.Base;

namespace CarDealer.Application.DataTransferObjects.Dtos.Identity
{
    public class UserInfoDto : BaseEntity
    {
        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string CurrentPassword { get; set; } = string.Empty;

        public string UpdatedPassword { get; set; } = string.Empty;
    }
}
