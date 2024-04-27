using System.ComponentModel.DataAnnotations;

namespace Route._3TiersArchitecture.PL.Models.Account
{
	public class SignUpViewModel
	{
		[Required(ErrorMessage = "User Name is required")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }


		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid Email")]
		public string Email { get; set; }



		[Required(ErrorMessage = "First Name is Required!")]
		[Display(Name = "First Name")]
		public string FirstName { get; set; }

		[Required(ErrorMessage = "Last Name is Required!")]
		[Display(Name = "Last Name")]
		public string LastName { get; set; }




		[Required(ErrorMessage = "Password is required")]
		[MinLength(5, ErrorMessage = "Minimum Password Length is 5")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[MinLength(5, ErrorMessage = "Minimum Password Length is 5")]
		[DataType(DataType.Password)]
		[Compare(nameof(Password), ErrorMessage = "Confirm Password dosen't match With Password")]
		public string ConfirmPassword { get; set; }


		public bool RememberMe { get; set; }
		public bool IsAgree { get; set; }

	}
}
