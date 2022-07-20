using System.Diagnostics;
using System.Net;

using ShoppingCart.UI.HttpClient.Interface;

namespace ShoppingCart.UI.HttpClient
{
  public class WebConnector : IWebConnector
  {
    private string _url;
    private readonly ILogger _logger;

    public WebConnector(ILogger logger, string url)
    {
      _logger = logger;
      _url = url;
    }

    public Uri Url { get; set; }

    public async Task<ConnectorResponse> SendAsync(string request)
    {
      throw new NotImplementedException();
    }
  }
}
