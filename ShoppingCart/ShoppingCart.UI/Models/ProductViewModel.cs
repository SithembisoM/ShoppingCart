using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.UI.Models
{
  public class ProductViewModel
  {
    //public ProductViewModel(
    //  string id,
    //  string name,
    //  string photo)
    //{
    //  Id = id;
    //  Name = name;
    //  Photo = photo;
    //}

    public ProductViewModel(
      string id,
      string name,
      decimal price,
      string photo)
    {
      Id = id;
      Name = name;
      Price = price;
      Photo = photo;
    }

    public string Id { get; set; }

    public string Name { get; set; }

    [DisplayFormat(DataFormatString = "{0:C0}")]
    public decimal Price { get; set; }

    public string Photo { get; set; }
  }
}
