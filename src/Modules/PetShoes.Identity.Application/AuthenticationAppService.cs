using Microsoft.Extensions.Configuration;
using Authorization.Configurations;
using Authorization.Models;
using Authorization.Token;
using PetShoes.Identity.Application.AppAuthentication.Inputs;
using PetShoes.Identity.Application.AppAuthentication.Interfaces;
using PetShoes.Identity.Application.AppAuthentication.Mapping;
using PetShoes.Identity.Domain.Interfaces;

namespace PetShoes.Identity.Application
{
    public class AuthenticationAppService : IAuthenticationAppService
    {
        private readonly IConfiguration _configuration;
        private readonly ICustomerRepository _customerRepository;
        public AuthenticationAppService(IConfiguration configuration,
                                        ICustomerRepository customerRepository)
        {
            _configuration = configuration;
            _customerRepository = customerRepository;
        }

        public async Task<TokenModel> LoginAsync(LoginInput loginInput, SigningConfigurations signingConfigurations)
        {
            var customer = await _customerRepository
                                    .GetByEmailAsync(loginInput.Login)
                                    .ConfigureAwait(false);

            if (customer is null)
                return default!;

            //var checkPwd = PasswordHasher.Verify(loginInput.Password, customer.Password);

            //if (!checkPwd)
            //    return default!;

            var customerModel = customer.ToMap();

            var tokenIssuer = _configuration.GetSection("TokenConfigurations:Issuer").Value!;
            var tokenAudience = _configuration.GetSection("TokenConfigurations:Audience").Value!;
            var expiresToken = int.Parse(_configuration.GetSection("TokenConfigurations:Expires").Value!);

            var token = GenerateToken.GetToken(customerModel.Id,
                                               customerModel.Login,
                                               customerModel.Name,
                                               customerModel.Role,
                                               tokenIssuer,
                                               tokenAudience,
                                               signingConfigurations,
                                               expiresToken,
                                               true);

            return token;
        }
    }
}
