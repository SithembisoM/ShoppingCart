using ShoppingCart.Model.DTO;
using ShoppingCart.Service.Service.Interface;

namespace ShoppingCart.Service.Service
{
  public class ProductService : IProductService
  {
    public Task<IList<Product>> GetProductsAsync()
    {
      var list = new List<Product>
      {
        new Product()
        {
          Description = "One",
          Id = 1,
          Name = "One",
          Photo = "",
          Price = 10
        },
        new Product()
        {
          Description = "Two    ",
          Id = 2,
          Name = "Two",
          Photo = "",
          Price = 10
        }
      };

      return Task.FromResult<IList<Product>>(list);
    }

    public Task<Product> GetProductAsync(int productId)
    {
      throw new NotImplementedException();
    }
  }
}
