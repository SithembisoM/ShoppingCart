using ShoppingCart.UI.Models;
using ShoppingCart.UI.Repositories.Interface;
using ShoppingCart.UI.Service.Interface;

namespace ShoppingCart.UI.Service
{
  public class ProductService : IProductService
  {
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    public Task<IEnumerable<ProductViewModel>> GetProductsAsync()
    {
      return _productRepository.GetProducts();
    }

    public Task<Product> GetProductAsync(int productId)
    {
      return _productRepository.GetProductById(productId);
    }
  }
}
