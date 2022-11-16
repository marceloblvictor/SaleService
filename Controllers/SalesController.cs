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

        public SalesController(CustomersClient customersClient)
        {
           _customersClient = customersClient;
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var response =  await _customersClient.GetAllCustomersAsync();

            return Ok(response);
        }

        [HttpPost("customers")]
        public async Task<IActionResult> CreateCustomer(CustomerCreateRequestDTO request)
        {
            await _customersClient.CreateCustomerAsync(request);

            return Ok("Usuário criado com sucesso!");
        }
    }
}
