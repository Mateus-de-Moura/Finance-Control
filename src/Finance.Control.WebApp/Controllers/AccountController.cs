using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;
using Finance.Control.webApp.ViewModel;
using Finance.Control.Application.Services;
using Ardalis.Result;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Finance.Control.webApp.Controllers
{
    public class AccountController(AppUserService appUserService) : Controller
    {
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            var model = new AccountLoginViewModel();

            return View(model);
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(AccountLoginViewModel model)
        {
            if (ModelState.IsValid == false)
                return View(model);

            var user = await appUserService.AuthAsync(model.Email, model.Password);

            if (user.IsNotFound())
            {
                ModelState.AddModelError(nameof(model.Email), "Usuário inválido");

                return View(model);
            }           

            if (user.IsSuccess is false)
            {
                ModelState.AddModelError(nameof(model.Email), "Usuário inválido");             

                return View(model);
            }

            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);

            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Value.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, user.Value.Name));
           
            identity.AddClaim(new Claim(ClaimTypes.Role, user.Value.UserRole.Name.ToString()));       
             
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                });

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public new async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction(nameof(Login));
        }

    }
}
