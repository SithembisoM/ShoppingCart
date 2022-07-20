using ShoppingCart.Api.Models;
using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.Repositories.Interface
{
  public interface ICartRepository
  {
    Task<IEnumerable<ItemViewModel>> Get(string userName);

    Task Add(ShoppingDetail item);

    Task<IEnumerable<ItemViewModel>> Update(int basketItemId, int quantity);

    IEnumerable<ItemViewModel> Delete(int basketItemId);

    IEnumerable<ItemViewModel> DeleteAll(int userId);
  }
}
