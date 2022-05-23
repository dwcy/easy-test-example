namespace UnitTests.InfrastructureTests.Contexts.ShoppingCarts
{

    public class ShoppingCartAdapterTests : IClassFixture<ShoppingCartFixture>
    {
        private readonly ShoppingCartFixture _fixture;

        public ShoppingCartAdapterTests(ShoppingCartFixture shoppingCartFixture)
        {
            _fixture = shoppingCartFixture;
        }

        [Fact]
        public async Task WhenCreatingACustomerInDatabase_ProvidedCustomerWithBasicDetails_CustomerIsNotNull()
        {
            await _fixture.CreateCustomer();

            var customer = await _fixture.WebshopDbContext.Customers.FirstOrDefaultAsync();

            Assert.Equal("Queens", customer.FirstName);

        }

    }
}
