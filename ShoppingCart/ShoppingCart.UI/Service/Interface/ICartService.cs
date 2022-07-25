using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.Service.Interface
{
  public interface ICartService
  {
    Task /*<IEnumerable<ItemViewModel>>*/ AddAsync(int id, string userName);

    Task QuantityAsync(int id, int quantity);

    Task ClearAsync(string userName);

    Task DeleteByIdAsync(int id);

    Task<IEnumerable<ItemViewModel>> GetItemsAsync(string userName);
  }
}
