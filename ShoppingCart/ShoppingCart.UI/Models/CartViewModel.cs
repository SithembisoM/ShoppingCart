namespace ShoppingCart.UI.Models
{
  public class CartViewModel
  {
    public CartViewModel(Product product, int quantity)
    {
      Product = product;
      Quantity = quantity;
    }

    public Product Product { get; set; }

    public int Quantity { get; set; }
  }
}