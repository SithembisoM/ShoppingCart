using Microsoft.AspNetCore.Mvc;

using ShoppingCart.Model.DTO;
using ShoppingCart.Service.Service.Interface;

namespace ShoppingCart.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProductController : Controller
  {
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
      _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      try
      {
        IList<Product> products = await _productService.GetProductsAsync();
        return Ok(products);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }

    [HttpGet("{productId}")]
    public async Task<IActionResult> Get(int productId)
    {
      try
      {
        Product? product = await _productService.GetProductAsync(productId);

        if (product == null)
        {
          return NotFound();
        }

        return Ok(product);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.Message);
      }
    }
  }
}
