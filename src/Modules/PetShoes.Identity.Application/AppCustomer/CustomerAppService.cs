using PetShoes.Identity.Application.AppCustomer.Interface;
using PetShoes.Identity.Domain.Interfaces;
using PetShoes.Identity.Repositories.Repository;

namespace PetShoes.Identity.Application.AppCustomer
{
    public class CustomerAppService : ICustomerAppService
    {

        private readonly ICustomerRepository _customerRepository;

        public CustomerAppService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public async Task<Customer> InsertAsync(Customer customerInput)
        {
            await _customerRepository
                            .InsertAsync(customerInput)
                            .ConfigureAwait(false);

            return customerInput; //TODO :: VERIFICAR ESTE RETORNO

        }
    }
}
