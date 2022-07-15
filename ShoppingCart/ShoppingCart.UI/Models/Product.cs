namespace ShoppingCart.UI.Models
{
  public class Product
  {
    public Product(
      string id,
      string name,
      string photo,
      double price)
    {
      Id = id;
      Name = name;
      Photo = photo;
      Price = price;
    }

    //public Product()
    //{
    //  throw new NotImplementedException();
    //}

    public string Id { get; set; }

    public string Name { get; set; }

    public double Price { get; set; }

    public string Photo { get; set; }
  }
}
