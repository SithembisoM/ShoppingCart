using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.Repositories.Interface
{
  public interface IProductRepository
  {
    Task<IEnumerable<ProductViewModel>> GetProducts();

    Task<Product> GetProductById(int productId);
  }
}
