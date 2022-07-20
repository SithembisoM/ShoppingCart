using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using ShoppingCart.UI.Models;
using ShoppingCart.UI.Service.Interface;

namespace ShoppingCart.UI.Controllers
{
  [Authorize]
  public class CartController : Controller
  {
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
      _cartService = cartService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      string? userName = GetCurrentUserAsync();

      if (userName == null)
      {
        return BadRequest();
      }

      IEnumerable<ItemViewModel> cartItems = await _cartService.GetItemsAsync(userName);

      if (cartItems == null)
      {
        throw new Exception($"No items in the cart for user : {userName}");
      }

      ViewBag.TotalAmount = cartItems.Sum(c => c.TotalAmount);
      ViewBag.TotalCount = cartItems.Count();

      return View(cartItems);
    }

    public ActionResult Add(int id)
    {
      string? userName = GetCurrentUserAsync();

      if (userName == null)
      {
        return BadRequest();
      }

      var items = _cartService.AddAsync(id, userName);

      return RedirectToAction("Index");
    }

    public ActionResult Remove(string id)
    {
      return RedirectToAction("Index");
    }

    public ActionResult UpdateQuantity(int itemId, int quantity)
    {
      return RedirectToAction("Index");
    }

    private string? GetCurrentUserAsync() => HttpContext.User?.Identity?.Name;
  }
}
