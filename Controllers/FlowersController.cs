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
                Category = "Roses",
                ImageUrl = "/images/rose-bouquet.jpg"
            },
            new Flower
            {
                Id = 2,
                Name = "Tulips",
                Description = "Fresh tulips",
                Price = 18,
                Category = "Spring",
                ImageUrl = "/images/tulips.jpg"
            },
            new Flower
            {
                Id = 3,
                Name = "Sunflower Sunshine",
                Description = "Bright sunflowers that add warmth to any room",
                Price = 22,
                Category = "Seasonal",
                ImageUrl = "/images/sunflower-sunshine.jpg"
            },
            new Flower
            {
                Id = 4,
                Name = "White Lily Arrangement",
                Description = "Elegant lilies with a clean, graceful look",
                Price = 28,
                Category = "Lilies",
                ImageUrl = "/images/white-lily-arrangement.jpg"
            },
            new Flower
            {
                Id = 5,
                Name = "Peony Dream",
                Description = "Soft and full peonies for a luxurious bouquet",
                Price = 34,
                Category = "Luxury",
                ImageUrl = "/images/peony-dream.jpg"
            },
            new Flower
            {
                Id = 6,
                Name = "Daisy Field Mix",
                Description = "Cheerful daisies mixed with fresh greenery",
                Price = 16,
                Category = "Everyday",
                ImageUrl = "/images/daisy-field-mix.jpg"
            },
            new Flower
            {
                Id = 7,
                Name = "Orchid Elegance",
                Description = "Refined orchids for a modern floral statement",
                Price = 42,
                Category = "Exotic",
                ImageUrl = "/images/orchid-elegance.jpg"
            },
            new Flower
            {
                Id = 8,
                Name = "Hydrangea Cloud",
                Description = "Full hydrangea blooms with a soft pastel feel",
                Price = 30,
                Category = "Classic",
                ImageUrl = "/images/hydrangea-cloud.jpg"
            },
            new Flower
            {
                Id = 9,
                Name = "Mixed Flower Bouquet",
                Description = "A vibrant mix of roses, lilies, daisies, and seasonal blooms",
                Price = 32,
                Category = "Bouquets",
                ImageUrl = "/images/mixed-flower-bouquet.jpg"
            }
        };

        return View(flowers);
    }

    public IActionResult Customize()
    {
        ViewData["BodyClass"] = "customize-page";
        return View();
    }
}