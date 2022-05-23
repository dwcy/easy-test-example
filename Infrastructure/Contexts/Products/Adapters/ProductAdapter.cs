using Domain.Contexts.Products;

namespace Infrastructure.Contexts.Products.Adapters
{
    public class ProductAdapter : IProductAdapter
    {
        private readonly IProductRepository _productRepository;

        public ProductAdapter(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(Guid id)
        {
            return _productRepository.GetProductById(id);
        }
    }
}
