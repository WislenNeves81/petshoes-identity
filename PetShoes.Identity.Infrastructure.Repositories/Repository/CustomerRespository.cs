using Marraia.MongoDb.Repositories;
using Marraia.MongoDb.Repositories.Interfaces;
using PetShoes.Identity.Domain.Interfaces;
using PetShoes.Identity.Repositories.Repository;

namespace PetShoes.Identity.Infrastructure.Repositories.Repository
{
    public class CustomerRespository : MongoDbRepositoryStandard<Customer, Guid>, ICustomerRepository
    {
        public CustomerRespository(IMongoContext context) : base(context) { }

        public async Task InsertAsync(Customer customer)
        {
            await Collection
                    .InsertOneAsync(customer)
                    .ConfigureAwait(false);
        }
    }
}
