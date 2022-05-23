using Domain.Entities;

namespace Domain.Contexts.Products
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductById(Guid id);
    }
}
