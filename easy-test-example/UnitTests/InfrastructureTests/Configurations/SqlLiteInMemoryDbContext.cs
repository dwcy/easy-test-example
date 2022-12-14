using Microsoft.Data.Sqlite;
using System.Data.Common;

namespace UnitTests.InfrastructureTests.Configurations
{
    public class SqlLiteInMemoryDbContext : WebshopDbContext
    {
        public SqlLiteInMemoryDbContext(): base(CreateDbContextOptions())
        {
            base.Database.EnsureDeleted();
            base.Database.EnsureCreated();
        }

        private static DbContextOptions<WebshopDbContext> CreateDbContextOptions()
        { 
           var dbContextBuilder = new DbContextOptionsBuilder<WebshopDbContext>()
                .UseSqlite(CreateInMemoryDatabase());

            return dbContextBuilder.Options;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("DataSource=:memory:");

            connection.Open();

            return connection;
        }
    }
}
