using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using NSubstitute;
using PetShoes.Identity.Application.AppCustomer;
using PetShoes.Identity.Application.AppCustomer.Input;
using PetShoes.Identity.Application.AppCustomer.ViewModel;
using PetShoes.Identity.Domain.Interfaces;
using PetShoes.Identity.Repositories.Repository;
using PetShoes.Identity.Tests.Services.Generate;

namespace PetShoes.Identity.Tests.Services
{
    public class CustomerAppServiceTest
    {
        private CustomerAppService _customerAppService;
        private ICustomerRepository _customerRepository;
        private Faker _faker;

        private const int defaultReceived = 1;

        public CustomerAppServiceTest()
        {
            _customerRepository = Substitute.For<ICustomerRepository>();
            _customerAppService = new CustomerAppService(_customerRepository);

            _faker = new Faker();
        }
        [Fact]
        public async Task GetCustomerByIdAsync_When_Returns_Value()
        {
            //Arrange
            var customerId = _faker.Random.Guid();
            var customer = GenerateFakerCustomer.CreateCustomerObject(customerId);
            _customerRepository.GetCustomerByIdAsync(Arg.Any<Guid>()).Returns(customer);

            //Act
            var result = await _customerAppService.GetCustomerByIdAsync(customerId);

            //Assert
            result.Should().BeOfType<CustomerViewModel>();

            await _customerRepository
                    .Received(defaultReceived)
                    .GetCustomerByIdAsync(Arg.Any<Guid>());
        }

        [Fact]
        public async Task GetCustomerByIdAsync_When_Do_Not_Return_Value()
        {
            //Arrange
            var customerId = _faker.Random.Guid();
            _customerRepository.GetCustomerByIdAsync(Arg.Any<Guid>())!.Returns(default(Customer));

            //Act
            var result = await _customerAppService.GetCustomerByIdAsync(customerId);

            //Assert
            result.Should().BeNull();
        }


        [Fact]
        public async Task InsertCustomerAsync_When_Email_Exists()
        {
            //Arrange
            var name = _faker.Person.FullName;
            var email = _faker.Person.Email;
            var cpf = _faker.Person.Cpf(false);
            var phone = _faker.Person.Phone;
            var city = _faker.Person.Address.City;
            var uf = _faker.Person.Address.State;
            var password = _faker.Random.AlphaNumeric(8);

            var customerInput = new CustomerInput();
            customerInput.Name = name;
            customerInput.Email = email;
            customerInput.Cpf = cpf;
            customerInput.Phone = phone;
            customerInput.City = city;
            customerInput.UF = uf;
            customerInput.Password = password;

            var customer = GenerateFakerCustomer.CreateCustomerObject(name, email, cpf, phone, city, uf, password);
            _customerRepository.GetByEmailAsync(Arg.Any<string>()).Returns(customer);

            //Act
            var result = await _customerAppService.InsertAsync(customerInput);

            //Assert
            result.Should().BeNull();

            await _customerRepository
                    .Received(defaultReceived)
                    .GetByEmailAsync(Arg.Any<string>());
        }

        [Fact]
        public async Task InsertCustomerAsync_When_Email_Exist()
        {
            //Arrange
            var name = _faker.Person.FullName;
            var email = _faker.Person.Email;
            var cpf = _faker.Person.Cpf(false);
            var phone = _faker.Person.Phone;
            var city = _faker.Person.Address.City;
            var uf = _faker.Person.Address.State;
            var password = _faker.Random.AlphaNumeric(8);

            var customerInput = new CustomerInput();
            customerInput.Name = name;
            customerInput.Email = email;
            customerInput.Cpf = cpf;
            customerInput.Phone = phone;
            customerInput.City = city;
            customerInput.UF = uf;
            customerInput.Password = password;

            var existingCustomer = GenerateFakerCustomer.CreateCustomerObject(name, email, cpf, phone, city, uf, password);
            _customerRepository.GetByEmailAsync(email).Returns(existingCustomer);

            //Act
            var result = await _customerAppService.InsertAsync(customerInput);

            //Assert
            result.Should().BeNull();

            await _customerRepository
                    .Received(defaultReceived)
                    .GetByEmailAsync(Arg.Any<string>());
        }
        [Fact]
        public async Task InsertCustomerAsync_When_CPF_Exist()
        {
            //Arrange
            var name = _faker.Person.FullName;
            var email = _faker.Person.Email;
            var cpf = _faker.Person.Cpf(false);
            var phone = _faker.Person.Phone;
            var city = _faker.Person.Address.City;
            var uf = _faker.Person.Address.State;
            var password = _faker.Random.AlphaNumeric(8);

            var customerInput = new CustomerInput();
            customerInput.Name = name;
            customerInput.Email = email;
            customerInput.Cpf = cpf;
            customerInput.Phone = phone;
            customerInput.City = city;
            customerInput.UF = uf;
            customerInput.Password = password;

            var existingCustomer = GenerateFakerCustomer.CreateCustomerObject(name, email, cpf, phone, city, uf, password);
            _customerRepository.GetByCpfAsync(cpf).Returns(existingCustomer);

            //Act
            var result = await _customerAppService.InsertAsync(customerInput);

            //Assert
            result.Should().BeNull();

            await _customerRepository
                    .Received(defaultReceived)
                    .GetByEmailAsync(Arg.Any<string>());
        }

    }
}
