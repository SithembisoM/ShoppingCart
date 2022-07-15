namespace ShoppingCart.Model.DTO
{
  public class CartItem
  {
    public int Id { get; set; }

    public int ProductId { get; set; }

    public virtual Product Product { get; set; } = new Product();

    public int Quantity { get; set; }

    public int UserId { get; set; }
  }
}
