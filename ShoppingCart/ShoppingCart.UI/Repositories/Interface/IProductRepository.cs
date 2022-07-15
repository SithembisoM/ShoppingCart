using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.Repositories.Interface
{
  public interface IProductRepository
  {
    IEnumerable<ProductViewModel> GetProducts();
    ProductViewModel GetProductById(int productId);
  }
}
