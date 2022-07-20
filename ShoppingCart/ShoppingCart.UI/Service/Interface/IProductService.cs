using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.Service.Interface
{
  public interface IProductService
  {
    Task<IEnumerable<ProductViewModel>> GetProductsAsync();

    Task<Product> GetProductAsync(int productId);
  }
}
