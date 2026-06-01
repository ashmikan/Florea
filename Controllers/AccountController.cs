using Floréa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Floréa.Controllers;

public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
        ViewData["Title"] = "Login";
        ViewData["BodyClass"] = "login-page";
        ViewData["HideSiteChrome"] = true;
        ViewData["FullWidthPage"] = true;

        return View(new LoginViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Login(LoginViewModel model)
    {
        ViewData["Title"] = "Login";
        ViewData["BodyClass"] = "login-page";
        ViewData["HideSiteChrome"] = true;
        ViewData["FullWidthPage"] = true;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        TempData["LoginNotice"] = $"Welcome back, {model.Email}.";
        return RedirectToAction("Index", "Home");
    }
}