using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Model;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    public class ProductsController : CustomBaseController
    {
        readonly IMapper _mapper;
        readonly IProductService _productService;
        public ProductsController(IMapper mapper, IService<Product> service, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }
        [HttpGet("GetProductsWithCategory")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWithCategory());
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDTO>>(products.ToList());
            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productsDto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productsDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            await _productService.RemoveAsync(product);
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

    }
}
