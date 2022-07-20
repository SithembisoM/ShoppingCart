using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Models;

namespace ShoppingCart.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CartsController : ControllerBase
  {
    private readonly ShoppingCartDBContext _context;

    public CartsController(ShoppingCartDBContext context)
    {
      _context = context;
    }

    [HttpGet]
    public IEnumerable<Shopping> GetCartItems()
    {
      List<Shopping> results = (
        from items in _context.Product
        join shop in _context.ShoppingDetails on items.Id equals shop.ShopId
        select new Shopping
        {
          Id = shop.ShopId,
          Name = items.Name,
          Photo = items.Photo,
          UserName = shop.UserName,
          Quantity = shop.Qty,
          TotalAmount = shop.TotalAmount,
        }).ToList();

      return results;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ShoppingDetail>> GetCartItem(int id)
    {
      ShoppingDetail? shoppingDetail = await _context.ShoppingDetails.FindAsync(id);

      if (shoppingDetail == null)
      {
        return NotFound();
      }

      return shoppingDetail;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCartItem(int id, ShoppingDetail shoppingDetail)
    {
      if (id != shoppingDetail.ShopId)
      {
        return BadRequest();
      }

      _context.Entry(shoppingDetail).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!CartItemExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<ShoppingDetail>> PostCartItem(ShoppingDetail shoppingDetail)
    {
      _context.ShoppingDetails.Add(shoppingDetail);
      await _context.SaveChangesAsync();

      return CreatedAtAction(
        "GetCartItem",
        new
        {
          id = shoppingDetail.ShopId
        },
        shoppingDetail);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCartItem(int id)
    {
      ShoppingDetail? shoppingDetail = await _context.ShoppingDetails.FindAsync(id);

      if (shoppingDetail == null)
      {
        return NotFound();
      }

      _context.ShoppingDetails.Remove(shoppingDetail);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool CartItemExists(int id)
    {
      if ((_context.ShoppingDetails?.Any(e => e.ShopId == id)).GetValueOrDefault()) return true;
      return false;
    }
  }
}
