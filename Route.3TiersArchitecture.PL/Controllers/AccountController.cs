using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Route._3TiersArchitecture.DAL.Models_Services_;
using Route._3TiersArchitecture.PL.Models.Account;
using Route._3TiersArchitecture.PL.Services;
using System.Threading.Tasks;

namespace Route._3TiersArchitecture.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationUser> _roleManager;
        private readonly IEmailSender _emailSender;
        private readonly IConfiguration _configs;
        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 IEmailSender emailSender, IConfiguration configs)

        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _configs = configs;
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
                        return RedirectToAction(nameof(Login));

                    foreach (var error in Result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }


                ModelState.AddModelError(string.Empty, "This user Email ALready Exist");
            }


            return View(model);
        }



        #endregion

        #region Sign In
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(SignInViewModel model)
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
                            return RedirectToAction(nameof(HomeController.Index), "/Home");
                          

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
            return RedirectToAction(nameof(Login));
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
                if (user is not null)
                {
                    var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordUrl = Url.Action("ResetPassword", "Account", new { email = user.Email, token = resetPasswordToken }, "https", "localhost:44309");
                    // await _userManager.SetEmailAsync(_configs["EmailSettings:SenderEmail"],
                    // model.Email, "Reset Password", resetPasswordUrl);

                    await _emailSender.SendAsync(
                    from: _configs["EmailSettings: SenderEmail"],
                    recipiens: model.Email,
                    subject: "Reset Your Password",
                    body: resetPasswordUrl);
                }
                ModelState.AddModelError(string.Empty, "There is no account with this email");
                return RedirectToAction(nameof(CheckYourInbox));
            }
            return View(model);
        }


        public IActionResult CheckYourInbox()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            TempData["email"] = email;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var email = TempData["email"] as string;
                var token = TempData["token"] as string;
                var user = await _userManager.FindByEmailAsync(email);
                if (user is not null)
                {

                    await _userManager.ResetPasswordAsync(user, token, model.Password);
                    return RedirectToAction(nameof(Login));
                }
                ModelState.AddModelError(string.Empty, "Url is not valid");
            }
            return View(model);
        }

    }
}
