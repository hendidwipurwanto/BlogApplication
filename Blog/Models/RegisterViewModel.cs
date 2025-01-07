using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class RegisterViewModel
    {
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password doesn match")]
        public string ConfirmPassword { get; set; }

        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public bool isCreator { get; set; }
    }
}
