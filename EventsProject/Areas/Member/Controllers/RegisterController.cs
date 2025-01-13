using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using EventsProject.Areas.Member.Models;
using Microsoft.AspNetCore.Authorization;  // AppUser modeliniz burada

namespace EventsProject.Areas.Member.Controllers
{
    [Area("Member")]

    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public RegisterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel model)
        {
           
            AppUser user = new AppUser
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                UserName = model.Username
            };

            if (model.Password == model.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn", "Login");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model); 
        }

    }
}