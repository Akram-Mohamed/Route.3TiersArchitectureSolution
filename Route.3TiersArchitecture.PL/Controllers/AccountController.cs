using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Route._3TiersArchitecture.DAL.Models_Services_;
using Route._3TiersArchitecture.PL.Models.Account;
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
                        return RedirectToAction(nameof(SignIn));

                    foreach (var error in Result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }


                ModelState.AddModelError(string.Empty, "This user Email ALready Exist");
            }


            return View(model);
        }



        #endregion

        #region Sign In
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var flag = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (flag)
                    {
                        var ressult = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (ressult.Succeeded)
                            return RedirectToAction(nameof(HomeController.Index), "Home");

                        if (ressult.IsLockedOut)
                            ModelState.AddModelError(string.Empty, "Your account is locked!");

                        if (ressult.IsNotAllowed)
                            ModelState.AddModelError(string.Empty, "Your email is not confirmed!");

                    }
                }
                ModelState.AddModelError(string.Empty, "Invalid Login");
            }
            return View(model);
        }
        #endregion

        #region Sign Out

        public async new Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(SignIn));
        }
        #endregion








        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendResetPasswordEmail(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                
            }
            return View(model);
        }





    }
}
