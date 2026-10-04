using System.ComponentModel.DataAnnotations;
namespace BookManager.Data.DTO
{
    public class RegisterDTO
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }

        [EmailAddress]
        [MaxLength(256)]
        public string? Email { get; set; }

        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
