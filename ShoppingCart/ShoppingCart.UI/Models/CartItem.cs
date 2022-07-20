namespace ShoppingCart.UI.Models
{
  public class CartItem
  {
    public CartItem()
    {
      Product = new Product();
    }

    public int Id { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; }

    public int Quantity { get; set; }

    public int UserId { get; set; }
  }
}
