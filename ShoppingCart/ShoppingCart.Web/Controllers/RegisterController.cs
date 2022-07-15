using Microsoft.AspNetCore.Mvc;

namespace ShoppingCart.Web.Controllers
{
  public class RegisterController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
