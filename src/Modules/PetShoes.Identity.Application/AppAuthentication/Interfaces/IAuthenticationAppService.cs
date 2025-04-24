using MyProfit.Authorization.Configurations;
using MyProfit.Authorization.Models;
using PetShoes.Identity.Application.AppAuthentication.Inputs;

namespace PetShoes.Identity.Application.AppAuthentication.Interfaces
{
    public interface IAuthenticationAppService
    {
        Task<TokenModel> LoginAsync(LoginInput loginInput, SigningConfigurations signingConfigurations);
    }
}
