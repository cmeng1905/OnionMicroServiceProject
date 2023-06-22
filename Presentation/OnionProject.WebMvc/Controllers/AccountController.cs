using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionProject.WebMvc.Models.Account;
using OnionProject.WebMvc.Services.Abstractions;

namespace OnionProject.WebMvc.Controllers
{
    public class AccountController : Controller
    {
        private IAuthApiService _authApiService;

        public AccountController(IAuthApiService authApiService)
        {
            _authApiService = authApiService;
        }

        public async Task<IActionResult> Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var authResult = await _authApiService.Authenticate(model.Username, model.Password);
            if (authResult)
                return RedirectToAction("Index", "Home");
            return View(model);
        }
        public IActionResult Logout()
        {
            _authApiService.Logout();
            return RedirectToAction("Index", "Home");
        }
    }
}
