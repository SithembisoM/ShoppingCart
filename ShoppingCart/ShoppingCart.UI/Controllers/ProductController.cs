using Microsoft.AspNetCore.Mvc;

using ShoppingCart.UI.Models;
using ShoppingCart.UI.Repositories.Interface;

namespace ShoppingCart.UI.Controllers
{
  public class ProductController : Controller
  {
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
      this._productRepository = productRepository;
    }

    [HttpGet]
    public IActionResult Index()
    {
      IEnumerable<ProductViewModel> productList = _productRepository.GetProducts();

      return View(productList);
    }
  }
}
