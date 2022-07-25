namespace ShoppingCart.Api.Middleware;

public class ApiKeyMiddleware
{
  //Taken from https://www.c-sharpcorner.com/article/using-api-key-authentication-to-secure-asp-net-core-web-api/

  private readonly RequestDelegate _next;
  private const string Apikey = "XApiKey";

  public ApiKeyMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    if (!context.Request.Headers.TryGetValue(Apikey, out var extractedApiKey))
    {
      context.Response.StatusCode = 401;
      await context.Response.WriteAsync("Api Key was not provided ");
      return;
    }

    var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
    var apiKey = appSettings.GetValue<string>(Apikey);

    try
    {
      if (!apiKey.Equals(extractedApiKey))
      {
        context.Response.StatusCode = 401;
        await context.Response.WriteAsync("Unauthorized client");
        return;
      }
    }
    catch (Exception e)
    {
      throw new Exception(e.Message);
    }

    await _next(context);
  }
}