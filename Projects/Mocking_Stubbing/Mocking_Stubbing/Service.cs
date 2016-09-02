using NSubstitute;
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

        public Customer GetCustomer(int id)
        {
            return _repository.GetById(id);
        }
    }

    public class BadServiceTests
    {
        [Theory]
        [InlineData(1234)]
        [InlineData(9876)]
        public void GetUserCallsRepositoryWithCorrectValue(int id)
        {
            var customerRepository = Substitute.For<ICustomerRepository>();
            var service = new Service(customerRepository);

            var customer = service.GetCustomer(id);

            customerRepository.Received(1).GetById(id);
        }
    }
}
