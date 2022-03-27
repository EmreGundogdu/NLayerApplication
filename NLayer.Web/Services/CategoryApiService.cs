namespace NLayer.Web.Services
{
    public class CategoryApiService
    {
        readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
    }
}
