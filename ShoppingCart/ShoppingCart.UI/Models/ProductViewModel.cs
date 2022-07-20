using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.UI.Models
{
  public class ProductViewModel
  {
    public ProductViewModel(
      int id,
      string name,
      int? price,
      string photo)
    {
      Id = id;
      Name = name;
      Price = price;
      Photo = photo;
    }

    public int Id { get; set; }

    public string Name { get; set; }

    [DisplayFormat(DataFormatString = "{0:C}")]
    public int? Price { get; set; }

    public string Photo { get; set; }
  }
}
