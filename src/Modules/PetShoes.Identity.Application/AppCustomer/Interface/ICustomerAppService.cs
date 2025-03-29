using Microsoft.AspNetCore.Mvc;
using PetShoes.Identity.Repositories.Repository;

namespace PetShoes.Identity.Application.AppCustomer.Interface
{
    public interface ICustomerAppService
    {
        Task<Customer> InsertAsync(Customer customerInput);
      
    }
}
