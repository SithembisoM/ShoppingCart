using Newtonsoft.Json;
using ShoppingCart.UI.HttpClient.Interface;
using ShoppingCart.UI.Models;

namespace ShoppingCart.UI.HttpClient
{
  public class HttpClientHelper : IHttpClientHelper
  {
    private static readonly JsonSerializerSettings _jsonSerializerSettings;

    private static readonly Formatting _jsonFormatting;

    private readonly IWebConnector connector;

    //static VanguardAPIClient()
    //{
    //  _jsonSerializerSettings = new JsonSerializerSettings
    //  {
    //    NullValueHandling = NullValueHandling.Ignore
    //  };
    //  _jsonFormatting = Formatting.Indented;
    //}

    public Task<IEnumerable<ProductViewModel>> GetProductsAsync()
    {
      throw new NotImplementedException();
    }

    public Task<ProductViewModel> GetProductByIdAsync(int productId)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<CartViewModel> GetAsync(int userId)
    {
      throw new NotImplementedException();
    }

    public Task AddAsync(
      int productId,
      int quantity,
      int userId)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<ItemViewModel>> UpdateAsync(int basketItemId, int quantity)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<ItemViewModel>> DeleteAsync(int basketItemId)
    {
      throw new NotImplementedException();
    }

    public Task<IEnumerable<ItemViewModel>> DeleteAllAsync(int userId)
    {
      throw new NotImplementedException();
    }
  }
}
