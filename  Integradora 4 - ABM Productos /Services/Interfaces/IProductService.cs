using Integradora_4___ABM_Productos.Models.DTOs.Requests;
using Integradora_4___ABM_Productos.Models.DTOs.Responses;

namespace Integradora_4___ABM_Productos.Services.Interfaces;

public interface IProductService
{
    List<ProductForReadDto> GetAllProducts();
    ProductForReadDto? GetProductById(int id);
    ProductForReadDto CreateProduct(ProductForCreateDto dto);
    void UpdateProduct(int id, ProductForUpdateDto dto);
    void DeleteProduct(int id);
    
    List<ProductForReadDto> SearchProductsByName(string name);
    
    ProductStatsDto GetStats();
    
}