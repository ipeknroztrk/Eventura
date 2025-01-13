using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using EventsProject.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;

namespace EventsProject.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(
                    model.Username,
                    model.Password,
                    false, true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Hesabınız kilitlenmiştir. Lütfen daha sonra tekrar deneyiniz.");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı.");
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                   
                    return RedirectToAction("ResetPassword", new { username = model.Username });
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı bulunamadı.");
                }
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult ResetPassword(string username)
        {
            var model = new ResetPasswordViewModel { Username = username };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var result = await _userManager.ResetPasswordAsync(user, resetToken, model.NewPassword);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("SignIn");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı bulunamadı.");
                }
            }
            return View(model);
        }


        // Çıkış işlemi
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            // Kullanıcıyı çıkartıyoruz
            await _signInManager.SignOutAsync();

            // Kullanıcıyı "Index" sayfasına yönlendiriyoruz
            // Areas dışındaki "Home" controller ve "Index" action
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}