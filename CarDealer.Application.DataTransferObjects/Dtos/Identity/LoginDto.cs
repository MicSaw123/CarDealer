using System.ComponentModel.DataAnnotations;

namespace CarDealer.Application.DataTransferObjects.Dtos.Identity
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

    }
}
