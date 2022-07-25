using Newtonsoft.Json;

using ShoppingCart.UI.Models;
using ShoppingCart.UI.Repositories.Interface;

namespace ShoppingCart.UI.Repositories
{
  public class ProductRepository : IProductRepository
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public ProductRepository(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<ProductViewModel>> GetProducts()
    {
      var httpClient = GetHttpClient();

      List<Product>? products = null;

      HttpResponseMessage response = await httpClient.GetAsync($"api/Products");

      if (response.IsSuccessStatusCode)
      {
        string responseContent = await response.Content.ReadAsStringAsync();

        products = Convert_to_List(responseContent);
      }

      var productViewModel = new List<ProductViewModel>();

      if (products == null)
      {
        return productViewModel;
      }

      productViewModel.AddRange(
        products.Select(
          p => new ProductViewModel(
            id: p.Id,
            name: p.Name,
            price: p.Price,
            photo: p.Photo)));

      return productViewModel;
    }

    public async Task<Product> GetProductById(int productId)
    {
      var httpClient = GetHttpClient();

      Product? product = null;

      HttpResponseMessage response = await httpClient.GetAsync($"api/Products/{productId}");

      if (response.IsSuccessStatusCode)
      {
        string responseContent = await response.Content.ReadAsStringAsync();

        product = Convert(responseContent);
      }

      if (product == null)
      {
        return new Product();
      }

      return product;
    }

    private System.Net.Http.HttpClient GetHttpClient()
    {
      return _httpClientFactory.CreateClient("Product");
    }

    private static List<Product>? Convert_to_List(string apiResponse)
    {
      var settings = new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore
      };
      return JsonConvert.DeserializeObject<List<Product>>(apiResponse, settings);
    }

    private static Product? Convert(string apiResponse)
    {
      var settings = new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore
      };
      return JsonConvert.DeserializeObject<Product>(apiResponse, settings);
    }
  }
}
