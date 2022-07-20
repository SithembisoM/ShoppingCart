using ShoppingCart.Api.Models;
using ShoppingCart.UI.Models;
using ShoppingCart.UI.Repositories.Interface;
using ShoppingCart.UI.Service.Interface;

using Product = ShoppingCart.UI.Models.Product;

namespace ShoppingCart.UI.Service
{
  public class CartService : ICartService
  {
    private readonly ICartRepository _cartRepository;
    private readonly IProductRepository _productRepository;

    public CartService(ICartRepository cartRepository, IProductRepository productRepository)
    {
      _cartRepository = cartRepository;
      _productRepository = productRepository;
    }

    public async Task<IEnumerable<ItemViewModel>> AddAsync(int id, string userName)
    {
      Product getProduct = await _productRepository.GetProductById(id);

      if (getProduct == null)
      {
        return new List<ItemViewModel>();
      }

      var item = new ShoppingDetail
      {
        ProductId = getProduct.Id,
        UserName = userName,
        Qty = 1,
        TotalAmount = getProduct.Price,
        Description = getProduct.Name,
        ShoppingDate = DateTime.Now
      };

      await _cartRepository.Add(item);

      return await _cartRepository.Get(userName);
    }

    public Task<IEnumerable<CartItem>> QuantityAsync(int id, int quantity)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<CartItem>> ClearAsync(int userId)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<CartItem>> DeleteByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<ItemViewModel>> GetItemsAsync(string userName)
    {
      return await _cartRepository.Get(userName);
    }
  }
}
