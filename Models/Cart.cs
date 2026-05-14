namespace Floréa.Models;

public class Cart
{
    public List<CartItem> CartItems { get; set; } = new();

    public void AddItem(Flower flower)
    {
        var existingItem = CartItems.FirstOrDefault(item => item.Flower.Id == flower.Id);

        if (existingItem is not null)
        {
            existingItem.Quantity++;
            return;
        }

        CartItems.Add(new CartItem
        {
            Flower = flower,
            Quantity = 1
        });
    }

    public void RemoveItem(int flowerId)
    {
        var item = CartItems.FirstOrDefault(cartItem => cartItem.Flower.Id == flowerId);

        if (item is not null)
        {
            CartItems.Remove(item);
        }
    }
}