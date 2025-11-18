using CFP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CFP.Controllers
{
    public class ContasController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public ContasController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // Lógica de autenticação aqui
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Despesas");
                }
                ModelState.AddModelError(string.Empty, "Login inválido.");
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userManager.CreateAsync(new IdentityUser { UserName = model.Username }, model.Password).Result;
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
            }
            return View(model);
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction("Login");
        }
    }
}
