using PetShoes.Identity.Repositories.Repository;

namespace PetShoes.Identity.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task InsertAsync(Customer customer);
    }
}
