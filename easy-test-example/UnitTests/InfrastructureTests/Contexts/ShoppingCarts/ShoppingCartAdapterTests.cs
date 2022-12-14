using Domain.Contexts.ShoppingCarts;
using FakeItEasy;
using Infrastructure.Contexts.ShoppingCarts.Adapters;

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
            //Arrange
            await _fixture.CreateCustomer();
            
            //Act
            var customer = await _fixture.WebshopDbContext.Customers.FirstOrDefaultAsync();

            //Assert
            Assert.Equal("Queens", customer.FirstName);

        }


        [Fact]
        public async Task FakeTest()
        {
            //Arrange
            var shoppingCartRepository = A.Fake<IShoppingCartRepository>();
            var shoppingCartAdapter = new ShoppingCartAdapter(shoppingCartRepository);

            await _fixture.CreateCustomer();
            var customer = await _fixture.WebshopDbContext.Customers.FirstOrDefaultAsync();

            var shoppingCart = new ShoppingCart();
            shoppingCart.Customer = customer;
            shoppingCart.CustomerId = customer.Id;
            shoppingCart.Id = Guid.NewGuid();
            shoppingCart.Items = new List<CartItem> { new CartItem() { Id = Guid.NewGuid(), ProductId = Guid.NewGuid(), Quantity = 1 } };

            A.CallTo(() =>
                shoppingCartRepository.GetShoppingCartBycustomerId(customer.Id)
            ).Returns(shoppingCart);

            //Act
            var result = shoppingCartAdapter.GetShoppingCartByUserId(customer.Id);

            //Assert
            Assert.Equal(shoppingCart, result);

        }

    }
}
