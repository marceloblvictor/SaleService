using Microsoft.AspNetCore.Mvc;
using SalesService.Clients;
using SalesService.Models.DTO;

namespace SalesService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly CustomersClient _customersClient;
        private readonly ProductsClient _productsClient;

        public SalesController(CustomersClient customersClient, ProductsClient productsClient)
        {
            _customersClient = customersClient;
            _productsClient = productsClient;
        }

        /// <summary>
        /// Obter todos os clientes.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var response =  await _customersClient.GetAllCustomersAsync();

            return Ok(response);
        }

        /// <summary>
        /// Criar cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Customers")]
        public async Task<IActionResult> CreateCustomer(CustomerCreateRequestDTO request)
        {
            await _customersClient.CreateCustomerAsync(request);

            return Ok("Cliente criado com sucesso!");
        }

        /// <summary>
        /// Obter todos os produtos.
        /// </summary>
        /// <returns></returns>
        [HttpGet("Products")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productsClient.GetAllProductsAsync();

            return Ok(response);
        }

        /// <summary>
        /// Criar produto.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("Products")]
        public async Task<IActionResult> CreateProduct(ProductCreateRequestDTO request)
        {
            await _productsClient.CreateProductAsync(request);

            return Ok("Produto comprado com sucesso!");
        }
    }
}
