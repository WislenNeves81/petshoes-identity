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
            //userViewModel.LegacyId = customer.LegacyId;
            userViewModel.Login = customer.Email;
            userViewModel.Name = customer.Name;
            //userViewModel.Referral = customer.Settings.Referral;
            //userViewModel.Role = customer.Admin ? "admin" : "user";
            //userViewModel.ByExchange = customer.Settings.ByExchange;
            //userViewModel.StartExchange = customer.Settings.StartExchange;
            //userViewModel.Enterprise = customer.PersonTypeId == Domain.Entities.Enums.PersonTypes.Enterprise;
            //userViewModel.MasterAccount = customer.MasterAccount;

            return userViewModel;
        }
    }
}
