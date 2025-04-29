using Bogus;
using Bogus.Extensions.Brazil;
using PetShoes.Identity.Repositories.Repository;

namespace PetShoes.Identity.Tests.Services.Generate
{
    internal class GenerateFakerCustomer
    {
        private const string UtfType = "pt_BR";
        private const int IntEight = 8;
        public static Customer CreateCustomerObject(Guid id)
        {
            var customer = new Faker<Customer>(UtfType)
                                        .StrictMode(true)
                                        .RuleFor(c => c.Id, id)
                                        .RuleFor(c => c.Name, faker => faker.Person.FullName)
                                        .RuleFor(c => c.Email, faker => faker.Person.Email)
                                        .RuleFor(c => c.Identification, faker => faker.Person.Cpf())
                                        .RuleFor(c => c.Phone, faker => faker.Person.Phone)
                                        .RuleFor(c => c.City, faker => faker.Person.Address.City)
                                        .RuleFor(c => c.UF, faker => faker.Person.Address.State)
                                        .RuleFor(c => c.Password, faker => faker.Random.AlphaNumeric(IntEight))
                                        .RuleFor(c => c.Active, true)
                                        .RuleFor(c => c.Admin, faker => faker.Random.Bool())
                                        .RuleFor(c => c.Updated, faker => faker.Date.Past())
                                        .RuleFor(c => c.Created, faker => faker.Date.Past())
                                        .Generate();
            return customer;
        }
        
        public static Customer CreateCustomerObject(string name, string email, string cpf, string phone, string city, string uf, string password)
        {
            var customer = new Faker<Customer>(UtfType)
                                        .StrictMode(true)
                                        .RuleFor(c => c.Id, faker => faker.Random.Guid())
                                        .RuleFor(c => c.Name, faker => name)
                                        .RuleFor(c => c.Email, email)
                                        .RuleFor(c => c.Identification, cpf)
                                        .RuleFor(c => c.Phone, faker => faker.Person.Phone)
                                        .RuleFor(c => c.City, faker => faker.Person.Address.City)
                                        .RuleFor(c => c.UF, faker => faker.Person.Address.State)
                                        .RuleFor(c => c.Password, password)
                                        .RuleFor(c => c.Active, true)
                                        .RuleFor(c => c.Admin, faker => faker.Random.Bool())
                                        .RuleFor(c => c.Updated, faker => faker.Date.Past())
                                        .RuleFor(c => c.Created, faker => faker.Date.Past())
                                        .Generate();
            return customer;
        }
    }
}
