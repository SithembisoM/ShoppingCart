using Microsoft.AspNetCore.Mvc;

using ShoppingCart.Model.DTO;
using ShoppingCart.Service.Service.Interface;

namespace ShoppingCart.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CartController : Controller
  {
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
      _cartService = cartService;
    }

    [HttpGet("Get/{userId:int}")]
    public async Task<IActionResult> Get(int userId)
    {
      IList<CartItem> cartItems = await _cartService.GetItemsAsync(userId);
      return Ok(cartItems);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CartItem cartItem)
    {
      await _cartService.AddAsync(cartItem);
      return Created($"ShoppingCart", cartItem);
    }

    [HttpPut("ChangeQuantity/{cartItemId:int}/{quantity:int}")]
    public async Task<IActionResult> ChangeQuantity(int cartItemId, int quantity)
    {
      IList<CartItem> cartItem = await _cartService.QuantityAsync(cartItemId, quantity);

      if (cartItem != null)
      {
        return Ok(cartItem);
      }

      return NotFound("Item not found in the cart");
    }

    [HttpDelete("Clear/{userId:int}")]
    public async Task<IActionResult> Clear(int userId)
    {
      IList<CartItem> cartItems = await _cartService.ClearAsync(userId);
      return Ok(cartItems);
    }

    [HttpDelete("Delete/{cartItemId:int}")]
    public async Task<IActionResult> Delete(int cartItemId)
    {
      IList<CartItem> cartItems = await _cartService.DeleteByIdAsync(cartItemId);

      if (cartItems == null)
      {
        return NotFound("Item not found in the cart");
      }

      return Ok(cartItems);
    }
  }
}
