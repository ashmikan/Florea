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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddCustom(CustomBouquetRequest request)
    {
        if (request == null)
        {
            return Json(new { success = false, message = "Invalid request payload" });
        }

        // 1. Calculate price
        decimal price = 0;

        // Wrapper pricing
        decimal wrapperPrice = request.Wrapper switch
        {
            "Burlap" => 5.00m,
            "Pink Paper" => 4.00m,
            "Kraft Paper" => 3.00m,
            "Glass Vase" => 8.00m,
            _ => 3.00m // Default
        };
        price += wrapperPrice;

        // Ribbon pricing
        decimal ribbonPrice = request.Ribbon switch
        {
            "None" => 0.00m,
            _ => 1.00m
        };
        price += ribbonPrice;

        // Flowers pricing
        var flowerDetails = new List<string>();
        foreach (var f in request.Flowers)
        {
            if (f.Quantity <= 0) continue;

            decimal stemPrice = f.Name switch
            {
                "Rose" => 2.50m,
                "Tulip" => 2.00m,
                "Sunflower" => 3.00m,
                "Lily" => 3.50m,
                "Peony" => 4.00m,
                "Daisy" => 1.50m,
                "Orchid" => 5.00m,
                "Hydrangea" => 3.00m,
                "Baby's Breath" => 1.00m,
                _ => 0.00m
            };

            price += stemPrice * f.Quantity;
            flowerDetails.Add($"{f.Quantity}x {f.Name}");
        }

        // 2. Generate description
        var details = new List<string>
        {
            $"Wrapper: {request.Wrapper}",
            $"Ribbon: {request.Ribbon}"
        };
        if (flowerDetails.Any())
        {
            details.Add($"Flowers: {string.Join(", ", flowerDetails)}");
        }
        if (!string.IsNullOrWhiteSpace(request.Note))
        {
            string noteDisplay = string.IsNullOrWhiteSpace(request.NoteRecipient)
                ? $"\"{request.Note}\""
                : $"To {request.NoteRecipient}: \"{request.Note}\"";
            details.Add($"Note: {noteDisplay}");
        }

        string description = string.Join(" | ", details);

        // 3. Create a unique Flower object using GetHashCode of description
        int uniqueId = Math.Abs(description.GetHashCode());
        uniqueId = -uniqueId; // Keep it negative to avoid conflict with static IDs

        var customFlower = new Flower
        {
            Id = uniqueId,
            Name = "Custom Bouquet",
            Description = description,
            Price = price,
            ImageUrl = "/images/custom-bouquet.png",
            Category = "Customizable"
        };

        // 4. Add to cart
        var cart = HttpContext.Session.GetObject<Cart>(CartSessionKey) ?? new Cart();
        cart.AddItem(customFlower, 1);
        HttpContext.Session.SetObject(CartSessionKey, cart);

        return Json(new { success = true, itemCount = cart.CartItems.Sum(i => i.Quantity) });
    }
}

public class CustomBouquetRequest
{
    public string Wrapper { get; set; } = string.Empty;
    public string Ribbon { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public string NoteRecipient { get; set; } = string.Empty;
    public List<CustomFlowerRequestItem> Flowers { get; set; } = new();
}

public class CustomFlowerRequestItem
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
}