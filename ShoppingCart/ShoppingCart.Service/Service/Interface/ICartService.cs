using ShoppingCart.Model.DTO;

namespace ShoppingCart.Service.Service.Interface
{
  public interface ICartService
  {
    Task<CartItem> AddAsync(CartItem basketItem);

    Task<IList<CartItem>> QuantityAsync(int id, int quantity);

    Task<IList<CartItem>> ClearAsync(int userId);

    Task<IList<CartItem>> DeleteByIdAsync(int id);

    Task<IList<CartItem>> GetItemsAsync(int userId);
  }
}
