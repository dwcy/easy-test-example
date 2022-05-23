namespace UnitTests.InfrastructureTests.Contexts.ShoppingCarts
{
    /// <summary>
    /// This example test will fail becuase this testclass is not using IClassFixture (Compare with ShoppingCartAdapterTests)
    /// IClassFixture will instantiate the constructor once for all tests in the class
    /// "test class as context"-pattern
    /// </summary>
//    public class ShoppingCartAdapterWithoutIClassFixtureTests
//    {
//        private ShoppingCartFixture _fixture;

//        public ShoppingCartAdapterWithoutIClassFixtureTests()
//        { 
//            _fixture = new ShoppingCartFixture();
//        }

//        [Fact]
//        public async Task WhenCreatingACustomerInDatabase_ProvidedCustomerWithBasicDetails_CustomerIsNotNull()
//        {
//            await _fixture.CreateCustomer();

//            var customer = _fixture.WebshopDbContext.Customers.FirstOrDefaultAsync();

//            Assert.NotNull(customer);
//        }

//        [Fact]
//        public async Task WhenCreatingACustomerInDatabase_ProvidedSecondCustomerWithBasicDetails_TwoCustomersExist()
//        {
//            await _fixture.CreateCustomer("Queens2", "lab2");

//            var customer = await _fixture.WebshopDbContext.Customers.ToListAsync();

//            Assert.Equal(1, customer.Count);
//        }
//    }
}
