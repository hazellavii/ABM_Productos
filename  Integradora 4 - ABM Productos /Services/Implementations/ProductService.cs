using Integradora_4___ABM_Productos.Repositories.Implementations;

using Integradora_4___ABM_Productos.Models.DTOs.Responses;

using Integradora_4___ABM_Productos.Entities;
using Integradora_4___ABM_Productos.Models.DTOs.Requests;

using Integradora_4___ABM_Productos.Services.Interfaces;

namespace Integradora_4___ABM_Productos.Services.Implementations;

public class ProductService : IProductService
{
    private ProductRepository _repository = new ProductRepository();
    
    public List<ProductForReadDto> GetAllProducts()
    {
        var products = _repository.GetAllProducts();
        var result = new List<ProductForReadDto>();

        foreach (var product in products)
        {
            result.Add(new ProductForReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });
        }

        return result;
    }
    
    public ProductForReadDto? GetProductById(int id)
    {
        var product = _repository.GetProductById(id);

        if (product is null)
        {
            return null;
        }

        return new ProductForReadDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }
    
    public ProductForReadDto CreateProduct(ProductForCreateDto dto)
    {
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price
        };

        _repository.AddProduct(product);

        return new ProductForReadDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }
    
    public void UpdateProduct(int id, ProductForUpdateDto dto)
    {
        var product = _repository.GetProductById(id);

        if (product is null)
        {
            return;
        }

        product.Name = dto.Name;
        product.Price = dto.Price;

        _repository.UpdateProduct(product);
    }
    
    public void DeleteProduct(int id)
    {
        var product = _repository.GetProductById(id);

        if (product is null)
        {
            return;
        }

        _repository.DeleteProduct(product);
    }
    
    
    public List<ProductForReadDto> SearchProductsByName(string name)
    {
        var products = _repository.SearchProductsByName(name);
        var result = new List<ProductForReadDto>();

        foreach (var product in products)
        {
            result.Add(new ProductForReadDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            });
        }

        return result;
    }
    
    
    public ProductStatsDto GetStats()
    {
        var products = _repository.GetAllProducts();

        if (products.Count == 0)
        {
            return new ProductStatsDto
            {
                Total = 0,
                AveragePrice = 0,
                MostExpensiveName = string.Empty
            };
        }

        return new ProductStatsDto
        {
            Total = products.Count,
            AveragePrice = products.Average(p => p.Price),
            MostExpensiveName = products
                .OrderByDescending(p => p.Price)
                .First().Name
        };
    }
    
}