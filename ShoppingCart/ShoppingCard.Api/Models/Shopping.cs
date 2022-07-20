namespace ShoppingCart.Api.Models
{
  public class Shopping
  {
    public int Id { get; set; }

    public string Name { get; set; }

    public string Photo { get; set; }

    public string UserName { get; set; }

    public int? TotalAmount { get; set; }

    public int Quantity { get; set; }
  }
}
