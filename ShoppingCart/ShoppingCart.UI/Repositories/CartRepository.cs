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

    public Task<IEnumerable<ItemViewModel>> Update(int itemId, int quantity)
    {
            //System.Net.Http.HttpClient httpClient = GetHttpClient();

            //HttpResponseMessage response = await httpClient.PutAsJsonAsync($"api/cart/ChangeQuantity/{itemId}/{quantity}", );

            //if (response == null)
            //{
            //  return null;
            //}

            //return ConvertToList(response);

            throw new NotImplementedException();
    }

    public IEnumerable<ItemViewModel> Delete(int itemId)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<ItemViewModel> DeleteAll(int userId)
    {
      throw new NotImplementedException();
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

    private static Item? Convert(string apiResponse)
    {
      var settings = new JsonSerializerSettings
      {
        NullValueHandling = NullValueHandling.Ignore,
        MissingMemberHandling = MissingMemberHandling.Ignore
      };
      return JsonConvert.DeserializeObject<Item>(apiResponse, settings);
    }
  }
}
