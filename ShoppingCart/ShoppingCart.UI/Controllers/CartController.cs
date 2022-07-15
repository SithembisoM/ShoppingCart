using Microsoft.AspNetCore.Mvc;

using ShoppingCart.UI.Models;
using ShoppingCart.UI.Repositories.Interface;

namespace ShoppingCart.UI.Controllers
{
  public class CartController : Controller
  {
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository cartRepository)
    {
      _cartRepository = cartRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
      IEnumerable<CartViewModel> cartItems = _cartRepository.Get(1);
      return View(cartItems);
    }

    public ActionResult Buy(string id)
    {
      return RedirectToAction("Index");
    }

    public ActionResult Remove(string id)
    {
      return RedirectToAction("Index");
    }

    public ActionResult UpdateQuantity(int ItemId, int quantity)
    {
      return RedirectToAction("Index");
    }
  }
}
