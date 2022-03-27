using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NLayer.Core.DTOs;
using NLayer.Core.Model;
using NLayer.Core.Services;

namespace NLayer.Web.Controllers
{
    public class ProductsController : Controller
    {
        readonly IProductService _productService;
        readonly ICategoryService _categoryService;
        readonly IMapper _mapper;
        public ProductsController(IProductService productService, ICategoryService categoryService, IMapper mapper)
        {
            _productService = productService;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetProductsWithCategory());
        }
        public async Task<IActionResult> Save()
        {
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDTO>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDTOs)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddAsync(_mapper.Map<Product>(productDTOs));
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDTO>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name");
            return View();
        }
        public async Task<IActionResult> Update(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDTO>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", product.CategoryId);
            return View(_mapper.Map<ProductDTO>(product));
        }
        [HttpPost]
        public async Task<IActionResult> Update(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(_mapper.Map<Product>(productDTO));
                return RedirectToAction(nameof(Index));
            }
            var categories = await _categoryService.GetAllAsync();
            var categoriesDto = _mapper.Map<List<CategoryDTO>>(categories.ToList());
            ViewBag.categories = new SelectList(categoriesDto, "Id", "Name", productDTO.CategoryId);
            return View(productDTO);
        }
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
