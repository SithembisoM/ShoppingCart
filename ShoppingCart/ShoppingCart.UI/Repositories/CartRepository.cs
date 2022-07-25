using Newtonsoft.Json;

using ShoppingCart.Api.Models;
using ShoppingCart.UI.Models;
using ShoppingCart.UI.Repositories.Interface;

namespace ShoppingCart.UI.Repositories
{
  public class CartRepository : ICartRepository
  {
    private readonly IHttpClientFactory _httpClientFactory;

    public CartRepository(IHttpClientFactory httpClientFactory)
    {
      _httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<ItemViewModel>> Get(string username)
    {
      var httpClient = GetHttpClient();

      IList<ItemViewModel>? cartItems = null;

      HttpResponseMessage response = await httpClient.GetAsync($"api/carts");

      if (response.IsSuccessStatusCode)
      {
        string responseContent = await response.Content.ReadAsStringAsync();

        cartItems = ConvertToList(responseContent);
      }

      var cartViewModel = new List<ItemViewModel>();

      if (cartItems == null)
      {
        return cartViewModel;
      }

      cartViewModel.AddRange(
        cartItems.Where(c => c.UserName == username)
          .Select(
            p => new ItemViewModel(
              p.Id,
              p.Photo,
              p.Quantity,
              p.Name,
              p.UserName,
              p.TotalAmount)));

      return cartViewModel;
    }

    public async Task Add(ShoppingDetail item)
    {
      var httpClient = GetHttpClient();

      var content = JsonContent.Create(item);

      HttpResponseMessage response = await httpClient.PostAsync($"api/carts", content);
      response.EnsureSuccessStatusCode();
    }

    public async Task Update(int id, int quantity)
    {
      var httpClient = GetHttpClient();

      ShoppingDetail item = null;

      var response = await httpClient.GetAsync($"api/Carts/{id}");

      if (response.IsSuccessStatusCode)
      {
        string responseContent = await response.Content.ReadAsStringAsync();
        item = Convert(responseContent);
      }

      if (item == null)
      {
        return;
      }

      item.Qty = quantity;

      var content = JsonContent.Create(item);

      await httpClient.PutAsync($"api/carts/{id}", content);
    }

    public async Task Delete(int itemId)
    {
      System.Net.Http.HttpClient httpClient = GetHttpClient();

      await httpClient.DeleteAsync($"api/Carts/{itemId}");
    }

    public async Task DeleteAll(string userName)
    {
      System.Net.Http.HttpClient httpClient = GetHttpClient();

      await httpClient.DeleteAsync($"api/Carts");
    }

    private System.Net.Http.HttpClient GetHttpClient()
    {
      return _httpClientFactory.CreateClient("Cart");
    }

    private static List<ItemViewModel>? ConvertToList(string apiResponse)
    {
      var settings = new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore
      };
      return JsonConvert.DeserializeObject<List<ItemViewModel>>(apiResponse, settings);
    }

    private static ShoppingDetail? Convert(string apiResponse)
    {
      var settings = new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore
      };
      return JsonConvert.DeserializeObject<ShoppingDetail>(apiResponse, settings);
    }
  }
}
