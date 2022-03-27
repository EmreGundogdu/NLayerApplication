using AutoMapper;
using NLayer.Core.DTOs;
using NLayer.Core.Model;

namespace NLayer.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<ProductFeature, ProductFeatureDTO>().ReverseMap();
            CreateMap<ProductUpdateDTO, Product>();
            CreateMap<Product, ProductWithCategoryDTO>();
            CreateMap<Category, CategoryWithProductsDto>();
        }
    }
}
