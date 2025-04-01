using PetShoes.Identity.Repositories.Repository;

namespace PetShoes.Identity.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task InsertAsync(Customer customer);
        Task<Customer> GetByEmailAsync(string email);
        Task<Customer> GetByCpfAsync(string cpf);
        Task<Customer> GetCustomerByIdAsync(Guid customerId);
        Task<Customer> UpdateAsync(Customer customer);
        Task DeleteAsync(Guid customerId);
    }
}
