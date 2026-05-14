namespace Floréa.Models;

public class CartItem
{
    public Flower Flower { get; set; } = null!;

    public int Quantity { get; set; }
}