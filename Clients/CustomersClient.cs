using System.Text.Json;
using SalesService.Models;
using SalesService.Models.DTO;

namespace SalesService.Clients
{
    public class CustomersClient
    {
        public static string CUSTOMERS_API = "customersApi";
        public const string CUSTOMERS_CREATE_URL = "Customers/";
        public const string CUSTOMERS_GET_ALL_URL = "Customers/";

        private readonly HttpClient _client;

        public CustomersClient(IHttpClientFactory clientFactory) 
        { 
            _client = clientFactory.CreateClient(CUSTOMERS_API);
        }

        public async Task<List<Customer>> GetAllCustomersAsync()
        {
            var response = await _client.GetFromJsonAsync<List<Customer>>(_client.BaseAddress + CUSTOMERS_GET_ALL_URL);

            return response;
        }

        public async Task CreateCustomerAsync(CustomerCreateRequestDTO request)
        {
            await _client.PostAsJsonAsync(_client.BaseAddress + CUSTOMERS_CREATE_URL, new Customer { Name = request.Name });
        }
    }
}
