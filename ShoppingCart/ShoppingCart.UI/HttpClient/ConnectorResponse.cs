namespace ShoppingCart.UI.HttpClient
{
  public class ConnectorResponse
  {
        public ConnectorResponse()
        {
        }

        public ConnectorResponse(string response, ErrorObject error)
    {
      Response = response;
      Error = error;
    }

    public string Response { get; set; }

    public ErrorObject Error { get; set; }

    public int HttpStatusCode { get; set; }

    public DateTime? ResponseTime { get; set; }

    public DateTime StartTime { get; set; }
  }
}
