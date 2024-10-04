using System.ComponentModel.DataAnnotations;

namespace CarDealer.Application.DataTransferObjects.Dtos.Identity
{
    public record RegisterDto
    {
        [Required]

        public string Username { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]

        public string Password { get; set; } = string.Empty;

        [Required]

        public string ConfirmedPassword { get; set; } = string.Empty;

        [Required]
        public int CityId { get; set; }

        [Required]
        public int AccountTypeId { get; set; }
    }
}
