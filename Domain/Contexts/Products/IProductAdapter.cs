using Domain.Entities;

namespace Domain.Contexts.Products
{
    public interface IProductAdapter
    {
        List<Product> GetAllProducts();
        Product GetProductById(Guid id);
    }
}
