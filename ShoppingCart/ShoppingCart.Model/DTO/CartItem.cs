namespace ShoppingCart.Model.DTO
{
  public class CartItem
  {
    public int Id { get; set; }

    public int ProductId { get; set; }

    public virtual ProductItem ProductItem { get; set; } = new ProductItem();

    public int Quantity { get; set; }

    public int UserId { get; set; }
  }
}
