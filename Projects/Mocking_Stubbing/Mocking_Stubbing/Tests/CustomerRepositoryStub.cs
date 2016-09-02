namespace Mocking_Stubbing.Tests
{
    public class CustomerRepositoryStub : ICustomerRepository
    {
        public bool IsGoldCustomer { get; set; }

        public void Save(Customer customer)
        {
            throw new System.NotImplementedException();
        }

        public Customer GetById(int id)
        {
            return new Customer { IsGoldCustomer = IsGoldCustomer };
        }
    }
}