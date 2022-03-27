using Microsoft.AspNetCore.Mvc;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        readonly IProductService _productService;
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetProductsWithCategory());
        }
    }
}
