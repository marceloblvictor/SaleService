using SalesService.Models;
using SalesService.Models.DTO;

namespace SalesService.Clients
{
    public class ProductsClient
    {
        public static string PRODUCTS_API = "productsApi";
        public const string PRODUCTS_GET_ALL_URL = "Products/";
        public const string PRODUCTS_CREATE_URL = "Products/";

        private readonly HttpClient _client;

        public ProductsClient(IHttpClientFactory clientFactory) 
        { 
            _client = clientFactory.CreateClient(PRODUCTS_API);
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var response = await _client.GetFromJsonAsync<List<Product>>(_client.BaseAddress + PRODUCTS_GET_ALL_URL);

            return response;
        }

        public async Task CreateProductAsync(ProductCreateRequestDTO request)
        {
            await _client.PostAsJsonAsync(_client.BaseAddress + PRODUCTS_CREATE_URL, 
                new Product 
                { 
                    Description = request.Description,
                    Registration = request.Registration,
                    CustomerId = request.CustomerId
                });
        }
    }
}
