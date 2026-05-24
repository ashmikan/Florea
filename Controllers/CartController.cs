using Floréa.Infrastructure;
using Floréa.Models;
using Microsoft.AspNetCore.Mvc;

namespace Floréa.Controllers;

public class CartController : Controller
{
    private const string CartSessionKey = "Cart";

    public IActionResult Index()
    {
        var cart = HttpContext.Session.GetObject<Cart>(CartSessionKey) ?? new Cart();

        return View(cart);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(Flower flower, int quantity = 1)
    {
        var cart = HttpContext.Session.GetObject<Cart>(CartSessionKey) ?? new Cart();
        cart.AddItem(flower, quantity);
        HttpContext.Session.SetObject(CartSessionKey, cart);

        if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
        {
            return Json(new { success = true, itemCount = cart.CartItems.Sum(i => i.Quantity) });
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int flowerId)
    {
        var cart = HttpContext.Session.GetObject<Cart>(CartSessionKey) ?? new Cart();
        cart.RemoveItem(flowerId);
        HttpContext.Session.SetObject(CartSessionKey, cart);

        return RedirectToAction(nameof(Index));
    }
}