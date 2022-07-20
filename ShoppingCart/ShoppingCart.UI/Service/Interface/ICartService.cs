using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.Service.Interface
{
  public interface ICartService
  {
    Task<IEnumerable<ItemViewModel>> AddAsync(int id, string userName);

    Task<IEnumerable<CartItem>> QuantityAsync(int id, int quantity);

    Task<IEnumerable<CartItem>> ClearAsync(int userId);

    Task<IEnumerable<CartItem>> DeleteByIdAsync(int id);

    Task<IEnumerable<ItemViewModel>> GetItemsAsync(string userName);
  }
}
