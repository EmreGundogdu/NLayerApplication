namespace NLayer.Web.Services
{
    public class ProductApiService
    {
        readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
