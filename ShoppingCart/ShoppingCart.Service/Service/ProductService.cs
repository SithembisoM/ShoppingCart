using ShoppingCart.Model.DTO;
using ShoppingCart.Service.Service.Interface;

namespace ShoppingCart.Service.Service
{
  public class ProductService : IProductService
  {
    public Task<IList<ProductItem>> GetProductsAsync()
    {
      throw new NotImplementedException();
    }

    public Task<ProductItem> GetProductAsync(int productId)
    {
      throw new NotImplementedException();
    }
  }
}
