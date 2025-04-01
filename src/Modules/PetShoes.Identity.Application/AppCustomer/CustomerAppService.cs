using PetShoes.Identity.Application.AppCustomer.Input;
using PetShoes.Identity.Application.AppCustomer.Interface;
using PetShoes.Identity.Application.AppCustomer.Mapping;
using PetShoes.Identity.Application.AppCustomer.ViewModel;
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
        public async Task<CustomerViewModel> InsertAsync(CustomerInput customerInput)
        {
            var customer = await _customerRepository
                                    .GetByEmailAsync(customerInput.Email)
                                    .ConfigureAwait(false);

            if (customer != null)
                throw new Exception("Email já cadastrado");

            customer = await _customerRepository
                                .GetByCpfAsync(customerInput.Cpf)
                                .ConfigureAwait(false);

            if (customer != null)
                throw new Exception("Cpf já cadastrado");

            customer = new Customer(customerInput.Name,
                                    customerInput.Email,
                                    customerInput.Cpf,
                                    customerInput.Phone,
                                    customerInput.City,
                                    customerInput.UF,
                                    customerInput.Password);

            await _customerRepository
                            .InsertAsync(customer)
                            .ConfigureAwait(false);

            return customer.ToViewModel(); 

        }
        public async Task<CustomerViewModel> GetCustomerByIdAsync(Guid customerId)
        {

            var customer = await _customerRepository
                                    .GetCustomerByIdAsync(customerId)
                                    .ConfigureAwait(false);

            if (customer == null)
                throw new Exception("Cliente não encontrado");

            return customer.ToViewModel();
        }
        public async Task<CustomerViewModel> UpdateAsync(Guid customerId, CustomerInput customerInput)
        {
            var customer = await _customerRepository
                                    .GetCustomerByIdAsync(customerId)
                                    .ConfigureAwait(false);
            if (customer == null)
                throw new Exception("Cliente não encontrado");

            customer.Update(customerInput.Name,
                            customerInput.Email,
                            customerInput.Cpf,
                            customerInput.Phone,
                            customerInput.City,
                            customerInput.UF,
                            customerInput.Password);
            
            await _customerRepository
                            .UpdateAsync(customer)
                            .ConfigureAwait(false);
            
            return customer.ToViewModel();
        }
        public async Task DeleteAsync(Guid customerId)
        {
            var customer = await _customerRepository
                                    .GetCustomerByIdAsync(customerId)
                                    .ConfigureAwait(false);

            if (customer == null)
                throw new Exception("Cliente não encontrado");

            await _customerRepository
                            .DeleteAsync(customer.Id)
                            .ConfigureAwait(false);
        }

    }
}
