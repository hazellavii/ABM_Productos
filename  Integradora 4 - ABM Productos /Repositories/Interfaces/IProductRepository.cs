using Integradora_4___ABM_Productos.Entities;

namespace Integradora_4___ABM_Productos.Repositories.Interfaces;

public interface IProductRepository
{
    List<Product> GetAllProducts();
    Product? GetProductById(int id);
    void AddProduct(Product product);
    void UpdateProduct(Product product);
    void DeleteProduct(Product product);
}