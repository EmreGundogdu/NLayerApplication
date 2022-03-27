namespace NLayer.Core.DTOs
{
    public class CategoryWithProductsDto : CategoryDTO
    {
        public List<ProductDTO> Products { get; set; }
    }
}
