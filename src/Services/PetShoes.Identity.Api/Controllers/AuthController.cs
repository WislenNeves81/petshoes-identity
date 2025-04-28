using Marraia.Notifications.Base;
using Marraia.Notifications.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Authorization.Configurations;
using Authorization.Models;
using PetShoes.Identity.Application.AppAuthentication.Inputs;
using PetShoes.Identity.Application.AppAuthentication.Interfaces;

namespace PetShoes.Identity.Api.Controllers
{
    [Route("petshoes/api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthenticationAppService _authenticationAppService;

        public AuthController(INotificationHandler<DomainNotification> notification,
                              IAuthenticationAppService authenticationAppService)
            : base(notification)
        {
            _authenticationAppService = authenticationAppService;

        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(TokenModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<object> PostAuthAsync([FromBody] LoginInput loginInput, [FromServices] SigningConfigurations signingConfigurations)
        {
            var customerToken = await _authenticationAppService
                                            .LoginAsync(loginInput, signingConfigurations)
                                            .ConfigureAwait(false);

            return customerToken;
        }
    }
}
