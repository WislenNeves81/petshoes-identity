using PetShoes.Identity.Application.AppCustomer.Input;
using PetShoes.Identity.Application.AppCustomer.ViewModel;

namespace PetShoes.Identity.Application.AppCustomer.Interface
{
    public interface ICustomerAppService
    {
        Task<CustomerViewModel> InsertAsync(CustomerInput customerInput);
      
    }
}
