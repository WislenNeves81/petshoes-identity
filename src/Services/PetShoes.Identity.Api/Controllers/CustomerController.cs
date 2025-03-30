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
        //[ProducesResponseType(typeof(Customer), StatusCodes.Status200OK)]
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
    }
}
