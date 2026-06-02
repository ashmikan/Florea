using Floréa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Floréa.Controllers;

public class RegisterController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        ViewData["Title"] = "Register";
        ViewData["BodyClass"] = "login-page register-page";
        ViewData["HideSiteChrome"] = true;
        ViewData["FullWidthPage"] = true;

        return View(new RegisterViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(RegisterViewModel model)
    {
        ViewData["Title"] = "Register";
        ViewData["BodyClass"] = "login-page register-page";
        ViewData["HideSiteChrome"] = true;
        ViewData["FullWidthPage"] = true;

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        TempData["LoginNotice"] = $"Welcome to Floréa, {model.FirstName}. Please sign in to continue.";
        return RedirectToAction("Login", "Account");
    }
}