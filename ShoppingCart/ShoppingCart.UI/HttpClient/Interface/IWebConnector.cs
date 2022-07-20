namespace ShoppingCart.UI.HttpClient.Interface
{
  public interface IWebConnector
  {
    Uri Url { get; set; }
    Task<ConnectorResponse> SendAsync(string request);
  }
}
