using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PetShoes.Identity.Application.AppAuthentication.Interfaces;
using PetShoes.Identity.Application;
using PetShoes.Identity.Application.AppCustomer;
using PetShoes.Identity.Application.AppCustomer.Interface;
using Marraia.Notifications.Configurations;

namespace PetShoes.Identity.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection service)
        {
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            service.AddScoped<ICustomerAppService, CustomerAppService>();
            service.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            service.AddSmartNotification();
        }
    }
}
