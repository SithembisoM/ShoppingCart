using Microsoft.AspNetCore.Mvc;

using ShoppingCart.UI.Models;
using ShoppingCart.UI.Service.Interface;

namespace ShoppingCart.UI.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
      _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      IEnumerable<ProductViewModel> productList = await _productService.GetProductsAsync();

      return View(productList);
    }
  }
}
