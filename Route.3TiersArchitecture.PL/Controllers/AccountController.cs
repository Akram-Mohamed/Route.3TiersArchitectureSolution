using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Route._3TiersArchitecture.DAL.Models_Services_;
using Route._3TiersArchitecture.PL.Models.User;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.PL.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly RoleManager<ApplicationUser> _roleManager;
		public AccountController(UserManager<ApplicationUser> userManager,
								 SignInManager<ApplicationUser> signInManager)

		{
			_userManager = userManager;
			_signInManager = signInManager;

		}


		#region Sign UP

		[HttpGet]
		public IActionResult SignUp()
		{

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(model.UserName);

				if (user is null)
				{

					user = new ApplicationUser()
					{
						FName = model.FirstName,
						LName = model.LastName,
						UserName = model.UserName,
						Email = model.Email,
						IsAgree = true,
					};
					var Result = await _userManager.CreateAsync(user, model.Password);
					if (Result.Succeeded)
						return RedirectToAction(nameof(LogIn));

					foreach (var error in Result.Errors)
						ModelState.AddModelError(string.Empty, error.Description);
				}


				ModelState.AddModelError(string.Empty, "This user Email ALready Exist");
			}


			return View(model);
		}



		#endregion

		#region MyRegion
		public IActionResult LogIn()
		{

			return View();
		}
		#endregion
	}
}
