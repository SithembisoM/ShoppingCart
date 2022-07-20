using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.UI.Models
{
  public class ItemViewModel
  {
    public ItemViewModel(
      string argId,
      string argPhoto,
      int argQuantity,
      string argName,
      string argUserName,
      int? argTotalAmount)
    {
      Id = argId;
      UserName = argUserName;
      TotalAmount = argTotalAmount;
      Quantity = argQuantity;
      Name = argName;
      Photo = argPhoto;
    }

    public string Id { get; set; }

    public string Name { get; set; }

    public int Quantity { get; set; }

    public string Photo { get; set; }

    public string UserName { get; set; }

    [DisplayFormat(DataFormatString = "{0:C}")]
    public int? TotalAmount { get; set; }
  }
}
