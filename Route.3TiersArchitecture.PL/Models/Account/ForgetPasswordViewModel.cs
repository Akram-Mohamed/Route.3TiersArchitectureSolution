using System.ComponentModel.DataAnnotations;

namespace Route._3TiersArchitecture.PL.Models.Account
{
    public class ForgetPasswordViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
    }
}
