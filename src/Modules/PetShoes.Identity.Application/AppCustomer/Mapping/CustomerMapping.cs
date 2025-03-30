using PetShoes.Identity.Application.AppCustomer.ViewModel;
using PetShoes.Identity.Repositories.Repository;

namespace PetShoes.Identity.Application.AppCustomer.Mapping
{
    public static class CustomerMapping
    {
        public static CustomerViewModel ToViewModel(this Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                Created = customer.Created
            };
        }
    }
}
