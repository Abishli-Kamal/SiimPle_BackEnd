using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Siimple_Back__End.Models;
using Siimple_Back__End.View_models;
using System.Threading.Tasks;

namespace Siimple_Back__End.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            if (register == null) return BadRequest();
            AppUser user = new AppUser
            {
                UserName = register.UserName,
                Email = register.Email,
                Name = register.Name,
                Surname = register.SurName
            };
            IdentityResult result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                foreach (IdentityError eror in result.Errors)
                {
                    ModelState.AddModelError("", eror.Description);

                }
                return View();
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Login(LoginVm login)
        {
            if (!ModelState.IsValid) return View();

            AppUser user = await _userManager.FindByNameAsync(login.UserName);

            
            if (login.RememberMe)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, true, true);
                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "You have been dismissed for 5 minutes");
                        return View();
                    }
                    ModelState.AddModelError("", "Username and Password Incorrect");
                    return View();

                }
            }
            else
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, login.Password, false, true);
                if (!result.Succeeded)
                {
                    if (result.IsLockedOut)
                    {
                        ModelState.AddModelError("", "You have been dismissed for 5 minutes");
                        return View();
                    }
                    ModelState.AddModelError("", "Username and Password Incorrect");
                    return View();

                }
            }
            return RedirectToAction("Index", "Home");
        }
    }

}
