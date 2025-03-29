using Marraia.MongoDb.Configurations;
using Microsoft.Extensions.DependencyInjection;
using PetShoes.Identity.Domain.Interfaces;
using PetShoes.Identity.Infrastructure.Repositories.Repository;

namespace PetShoes.Identity.Infrastructure.IoC.Repository
{
    internal class RepositoryBootstrapper
    {
        internal void ChildServiceRegister(IServiceCollection service)
        {
            service.AddMongoDb();
            service.AddScoped<ICustomerRepository, CustomerRespository>();
        }
    }
}
