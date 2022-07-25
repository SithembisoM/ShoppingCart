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

      if (!cartItems.Any())
      {
        return RedirectToAction("Index", "Product");
      }

      ViewBag.TotalAmount = cartItems.Sum(c => c.TotalAmount);
      ViewBag.TotalCount = cartItems.Count();

      return View(cartItems);
    }

    public async Task<IActionResult> Add(int id)
    {
      string? userName = GetCurrentUserAsync();

      if (userName == null)
      {
        return BadRequest();
      }

      await _cartService.AddAsync(id, userName);

      return RedirectToAction("Index");
    }

    public async Task<IActionResult> Remove(int id)
    {
      string? userName = GetCurrentUserAsync();

      if (userName == null)
      {
        return BadRequest();
      }

      await _cartService.DeleteByIdAsync(id);

      return RedirectToAction("Index");
    }

    public async Task<IActionResult> UpdateQuantity(int id, int quantity)
    {
      if (quantity < 1)
      {
        return BadRequest();
      }

      await _cartService.QuantityAsync(id, quantity);

      return RedirectToAction("Index");
    }

    public ActionResult Checkout()
    {
      ViewBag.OrderNumber = 1;
      return View("Checkout");
    }

    private string? GetCurrentUserAsync() => HttpContext.User?.Identity?.Name;
  }
}
