using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Model;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        readonly IMapper _mapper;
        readonly IService<Product> _service;

        public ProductsController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDTO>>(products.ToList());
            return CreateActionResult(CustomResponseDTO<List<ProductDTO>>.Success(200, productsDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(200, productsDto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDTO productDto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDTO>(product);
            return CreateActionResult(CustomResponseDTO<ProductDTO>.Success(201, productsDto));
        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDTO productDto)
        {
            await _service.UpdateAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(product);
            return CreateActionResult(CustomResponseDTO<NoContentDTO>.Success(204));
        }

    }
}
