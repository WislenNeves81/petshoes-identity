using Marraia.MongoDb.Repositories;
using Marraia.MongoDb.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
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
        public async Task<Customer> GetByEmailAsync(string email)
        {
            return await Collection
                            .AsQueryable()
                            .Where(customer => customer.Email == email && customer.Active == true)
                            .FirstOrDefaultAsync();
        }
        public async Task<Customer> GetByCpfAsync(string cpf)
        {
            return await Collection
                            .AsQueryable()
                            .Where(customer => customer.Identification == cpf && customer.Active == true)
                            .FirstOrDefaultAsync();
        }
    }
}
