using Authorization.Configurations;
using Authorization.Models;
using PetShoes.Identity.Application.AppAuthentication.Inputs;

namespace PetShoes.Identity.Application.AppAuthentication.Interfaces
{
    public interface IAuthenticationAppService
    {
        Task<TokenModel> LoginAsync(LoginInput loginInput, SigningConfigurations signingConfigurations);
    }
}
