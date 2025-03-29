using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using PetShoes.Identity.Application.AppCustomer;
using PetShoes.Identity.Application.AppCustomer.Interface;

namespace PetShoes.Identity.Infrastructure.IoC.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection service)
        {
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            service.AddScoped<ICustomerAppService, CustomerAppService>();
        }
    }
}
