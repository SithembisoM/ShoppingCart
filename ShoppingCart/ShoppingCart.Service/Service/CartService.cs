using ShoppingCart.Model.DTO;
using ShoppingCart.Service.Service.Interface;

namespace ShoppingCart.Service.Service
{
  public class CartService : ICartService
  {
    public Task<CartItem> AddAsync(CartItem basketItem)
    {
      throw new NotImplementedException();
    }

    public Task<IList<CartItem>> QuantityAsync(int id, int quantity)
    {
      throw new NotImplementedException();
    }

    public Task<IList<CartItem>> ClearAsync(int userId)
    {
      throw new NotImplementedException();
    }

    public Task<IList<CartItem>> DeleteByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<IList<CartItem>> GetItemsAsync(int userId)
    {
      throw new NotImplementedException();
    }
  }
}
