using Shouldly;
using Xunit;

namespace Mocking_Stubbing.Tests
{
    public class ServiceTests
    {
        private readonly CustomerRepositoryStub _stub;
        private readonly Service _sut;

        public ServiceTests()
        {
            _stub = new CustomerRepositoryStub();
            _sut = new Service(_stub);
        }

        [Fact]
        public void Should_return_discount_of_90_for_gold_customer()
        {
            _stub.IsGoldCustomer = true;
            var customerDiscount = _sut.GetCustomerDiscount(0);
            customerDiscount.ShouldBe(90);
        }

        [Fact]
        public void Should_return_discount_of_0_for_none_gold_customer()
        {
            _stub.IsGoldCustomer = false;
            var customerDiscount = _sut.GetCustomerDiscount(0);
            customerDiscount.ShouldBe(0);
        }
    }
}