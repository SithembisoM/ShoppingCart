using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.Repositories.Interface
{
  public interface ICartRepository
  {
    IEnumerable<CartViewModel> Get(int userId);

    void Add(
      int productId,
      int quantity,
      int userId);

    IEnumerable<ItemViewModel> Update(int basketItemId, int quantity);

    IEnumerable<ItemViewModel> Delete(int basketItemId);

    IEnumerable<ItemViewModel> DeleteAll(int userId);
  }
}
