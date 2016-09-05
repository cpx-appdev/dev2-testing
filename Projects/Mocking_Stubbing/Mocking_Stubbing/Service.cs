using NSubstitute;
using Shouldly;
using Xunit;

namespace Mocking_Stubbing
{
    public class Service
    {
        private readonly ICustomerRepository _repository;

        public Service(ICustomerRepository repository)
        {
            _repository = repository;
        }

        // TODO TEST
        public void AddCustomer(Customer customer)
        {
            // Some Business Logic
            _repository.Save(customer);
        }

        // TODO TEST
        public int GetCustomerDiscount(int id)
        {
            var customer = _repository.GetById(id);

            if (customer.IsGoldCustomer)
                return 90;
            return 0;
        }

        public C GetCustomer(int id)
        {
            var byId = _repository.GetById(id);
            return new C { Id = byId.Id, Name = byId.Name };
        }
    }

    public class C
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Use stubs for queries and NOT mocks!
    public class ServiceTests
    {
        [Theory]
        [InlineData(1234, "Foo")]
        [InlineData(9876, "Boo")]
        public void GetUserCallsRepositoryWithCorrectValue(int id, string name)
        {
            var customerRepository = Substitute.For<ICustomerRepository>();
            var service = new Service(customerRepository);
            customerRepository.GetById(id).Returns(new Customer { Id = id, Name = name });

            var expected = new C { Id = id, Name = name };

            var result = service.GetCustomer(id);

            result.Id.ShouldBe(expected.Id);
            result.Name.ShouldBe(expected.Name);
        }
    }
}
