using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PetShoes.Identity.Infrastructure.IoC.Application;
using PetShoes.Identity.Infrastructure.IoC.Repository;

namespace PetShoes.Identity.Infrastructure.IoC
{
    public class RootBootstrapper
    {
        public void BootstrapperRegisterServices(IServiceCollection services)
        {
            new RepositoryBootstrapper().ChildServiceRegister(services);
            new ApplicationBootstrapper().ChildServiceRegister(services);
        }
    }
}
