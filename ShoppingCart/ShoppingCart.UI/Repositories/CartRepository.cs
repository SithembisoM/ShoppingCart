using ShoppingCart.UI.Models;
using ShoppingCart.UI.Repositories.Interface;

namespace ShoppingCart.UI.Repositories
{
  public class CartRepository : ICartRepository
  {
    public IEnumerable<CartViewModel> Get(int userId)
    {
      return new List<CartViewModel>()
      {
        new(
          new Product(
            id: "#1",
            name: "Name IS",
            photo: "",
            price: 200),
          19)
      };
    }

    public void Add(
      int productId,
      int quantity,
      int userId)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<ItemViewModel> Update(int basketItemId, int quantity)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<ItemViewModel> Delete(int basketItemId)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<ItemViewModel> DeleteAll(int userId)
    {
      throw new NotImplementedException();
    }
  }
}
