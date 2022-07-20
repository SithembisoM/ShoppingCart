namespace ShoppingCart.UI.HttpClient
{
  public class ErrorObject
  {
    public ErrorObject()
    {
      ErrorCode = 1;
      ErrorDescription = string.Empty;
      HttpStatusCode = 200;
    }

    public int ErrorCode { get; set; }

    public string ErrorDescription { get; set; }

    public int HttpStatusCode { get; set; }
  }
}