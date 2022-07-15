using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Web.Controllers
{
  public class LoginController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
