using ShoppingCart.UI.Models;
using ShoppingCart.UI.Repositories.Interface;

namespace ShoppingCart.UI.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private IEnumerable<ProductViewModel> _products;

    public ProductRepository(IEnumerable<ProductViewModel> products)
    {
      _products = products;
    }

    public IEnumerable<ProductViewModel> GetProducts()
    {
      _products = new List<ProductViewModel>()
      {
        new(
          id: "#1",
          name: "Product One",
          price: 1000,
          photo: "thumb1.gif"),
        new(
          id: "#2",
          name: "Product One",
          price: 1000,
          photo: "thumb1.gif"),
      };

      return _products;
    }

    public ProductViewModel GetProductById(int productId)
    {
      return _products.Single(s => s.Id.Equals((productId.ToString())));
    }
  }
}
