using System.ComponentModel.DataAnnotations;

namespace Eg.rel.AuthService.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
