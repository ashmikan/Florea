using Microsoft.AspNetCore.Mvc;
using Floréa.Models;

namespace Floréa.Controllers;

public class FlowersController : Controller
{
    public IActionResult Index()
    {
        ViewData["BodyClass"] = "flowers-page";
        
        var flowers = new List<Flower>
        {
            new Flower
            {
                Id = 1,
                Name = "Rose Bouquet",
                Description = "Romantic red roses",
                Price = 25,
                ImageUrl = "https://images.unsplash.com/photo-1518895949257-7621c3c786d7"
            },
            new Flower
            {
                Id = 2,
                Name = "Tulips",
                Description = "Fresh tulips",
                Price = 18,
                ImageUrl = "https://images.unsplash.com/photo-1520763185298-1b434c919102"
            }
        };

        return View(flowers);
    }
}