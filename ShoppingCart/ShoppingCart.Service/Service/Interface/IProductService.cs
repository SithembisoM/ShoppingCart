using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ShoppingCart.Model.DTO;

namespace ShoppingCart.Service.Service.Interface
{
  public interface IProductService
  {
    Task<IList<ProductItem>> GetProductsAsync();
    Task<ProductItem> GetProductAsync(int productId);
  }
}
