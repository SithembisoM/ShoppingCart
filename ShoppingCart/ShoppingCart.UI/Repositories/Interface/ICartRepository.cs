using ShoppingCart.Api.Models;
using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.Repositories.Interface;

public interface ICartRepository
{
  Task<IEnumerable<ItemViewModel>> Get(string userName);

  Task Add(ShoppingDetail item);

  Task Update(int basketItemId, int quantity);

  Task Delete(int basketItemId);

  Task DeleteAll(string userName);
}