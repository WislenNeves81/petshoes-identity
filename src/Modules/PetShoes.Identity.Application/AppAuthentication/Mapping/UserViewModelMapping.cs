using PetShoes.Identity.Application.AppAuthentication.ViewModel;
using PetShoes.Identity.Repositories.Repository;

namespace PetShoes.Identity.Application.AppAuthentication.Mapping
{
    internal static class UserViewModelMapping
    {
        internal static UserViewModel ToMap(this Customer customer)
        {
            var userViewModel = new UserViewModel();
            userViewModel.Id = customer.Id;
            userViewModel.Login = customer.Email;
            userViewModel.Name = customer.Name;
            userViewModel.Role = customer.Admin ? "admin" : "user";

            return userViewModel;
        }
    }
}
