using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.HttpClient.Interface
{
  public interface IHttpClientHelper
  {
    Task<IEnumerable<ProductViewModel>> GetProductsAsync();

    Task<ProductViewModel> GetProductByIdAsync(int productId);

    IEnumerable<CartViewModel> GetAsync(int userId);

    Task AddAsync(
      int productId,
      int quantity,
      int userId);

    Task<IEnumerable<ItemViewModel>> UpdateAsync(int basketItemId, int quantity);

    Task<IEnumerable<ItemViewModel>> DeleteAsync(int basketItemId);

    Task<IEnumerable<ItemViewModel>> DeleteAllAsync(int userId);
  }
}
