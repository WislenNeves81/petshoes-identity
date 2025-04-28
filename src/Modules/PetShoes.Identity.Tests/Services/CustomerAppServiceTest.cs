using Bogus;
using FluentAssertions;
using NSubstitute;
using PetShoes.Identity.Application.AppCustomer;
using PetShoes.Identity.Application.AppCustomer.ViewModel;
using PetShoes.Identity.Domain.Interfaces;
using PetShoes.Identity.Tests.Services.Generate;

namespace PetShoes.Identity.Tests.Services
{
    public class CustomerAppServiceTest
    {

        private ICustomerRepository _customerRepository;
        private CustomerAppService _customerAppService;
        private Faker _faker;

        private const int defaultReceived = 1;

        public CustomerAppServiceTest()
        {
            _customerRepository = Substitute.For<ICustomerRepository>();
            _customerAppService = new CustomerAppService(_customerRepository);
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
    }
}
