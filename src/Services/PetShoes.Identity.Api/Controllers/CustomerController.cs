using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PetShoes.Identity.Application.AppCustomer.Input;
using PetShoes.Identity.Application.AppCustomer.Interface;

namespace PetShoes.Identity.Api.Controllers
{
    [Route("petshoes/api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PostAsync([FromBody] CustomerInput customerInput)
        {
            var customer = await _customerAppService
                                            .InsertAsync(customerInput)
                                            .ConfigureAwait(false);

            return Ok(customer);
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAsync(Guid customerId)
        {
            var customer = await _customerAppService
                                            .GetCustomerByIdAsync(customerId)
                                            .ConfigureAwait(false);
            return Ok(customer);
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> PutAsync(Guid customerId, [FromBody] CustomerInput customerInput)
        {
            var customer = await _customerAppService
                                            .UpdateAsync(customerId, customerInput)
                                            .ConfigureAwait(false);
            return Ok(customer);
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteAsync(Guid customerId)
        {
            await _customerAppService
                    .DeleteAsync(customerId)
                    .ConfigureAwait(false);
            return Ok();
        }
    }
}
