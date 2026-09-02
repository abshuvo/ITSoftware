using System.ComponentModel.DataAnnotations;

namespace ITSoftware.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "ইউজার আইডি বা নাম লিখুন")]
        [Display(Name = "User ID / Username")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "পাসওয়ার্ড লিখুন")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; } = true;

        public string? ReturnUrl { get; set; }
    }
}

