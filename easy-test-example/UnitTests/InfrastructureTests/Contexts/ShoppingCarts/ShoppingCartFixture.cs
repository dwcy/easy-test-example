namespace UnitTests.InfrastructureTests.Contexts.ShoppingCarts
{
    public class ShoppingCartFixture : IDisposable
    {
        public WebshopDbContext WebshopDbContext { get; private set; }

        public List<Customer> Customers { get; set; }

        public ShoppingCartFixture()
        {
            Customers = new List<Customer>();
            WebshopDbContext = new SqlLiteInMemoryDbContext();
        }

        public async Task CreateCustomer(string firstName = "Queens",string lastName = "Lab")
        {
            await WebshopDbContext.Customers.AddAsync(
                new Customer() {
                  FirstName = firstName,
                  LastName = lastName
            });

            await WebshopDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            WebshopDbContext.Dispose();
        }
    }
}
