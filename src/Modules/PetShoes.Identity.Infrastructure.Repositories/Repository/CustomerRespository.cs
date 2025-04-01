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
        public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            return await Collection
                            .AsQueryable()
                            .Where(customer => customer.Id == customerId && customer.Active == true)
                            .FirstOrDefaultAsync();
        }
        public async Task<Customer> UpdateAsync(Customer customer)
        {
            await Collection
                    .ReplaceOneAsync(c => c.Id == customer.Id, customer)
                    .ConfigureAwait(false);
            return customer;
        }
        public async Task DeleteAsync(Guid customerId)
        {
            await Collection
                    .UpdateOneAsync(c => c.Id == customerId,
                                    Builders<Customer>.Update.Set(c => c.Active, false))
                    .ConfigureAwait(false);
        }
    }
}
