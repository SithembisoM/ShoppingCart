using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingCart.Api.Models;

namespace ShoppingCart.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ProductsController : ControllerBase
  {
    private readonly ShoppingCartDBContext _context;

    public ProductsController(ShoppingCartDBContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
      if (_context.Product == null)
      {
        return NotFound();
      }

      return await _context.Product.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
      if (_context.Product == null)
      {
        return NotFound();
      }

      Product? product = await _context.Product.FindAsync(id);

      if (product == null)
      {
        return NotFound();
      }

      return product;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Product product)
    {
      if (id != product.Id)
      {
        return BadRequest();
      }

      _context.Entry(product).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ProductExists(id))
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
    public async Task<ActionResult<Product>> PostProduct(Product product)
    {
      if (_context.Product == null)
      {
        return Problem("Entity set 'ShoppingCartDBContext.Products'  is null.");
      }

      _context.Product.Add(product);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetProduct", new { id = product.Id }, product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
      if (_context.Product == null)
      {
        return NotFound();
      }

      var product = await _context.Product.FindAsync(id);

      if (product == null)
      {
        return NotFound();
      }

      _context.Product.Remove(product);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool ProductExists(int id)
    {
      return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
    }
  }
}
