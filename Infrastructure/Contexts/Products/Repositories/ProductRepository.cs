using Domain.Contexts.Products;

namespace Infrastructure.Contexts.Products.Repositories
{
    internal class ProductRepository : IProductRepository
    {
        private readonly WebshopDbContext _context;

        public ProductRepository(WebshopDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(Guid id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
                throw new Exception("Product not found");

            return product;
        }
    }
}
