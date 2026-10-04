using Microsoft.AspNetCore.Mvc;
using Integradora_4___ABM_Productos.Services.Implementations;

using Integradora_4___ABM_Productos.Models.DTOs.Requests;

namespace Integradora_4___ABM_Productos.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private ProductService _service = new ProductService();
    
    
    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _service.GetAllProducts();

        return Ok(products);
    }
    
    
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var product = _service.GetProductById(id);

        if (product is null)
        {
            return NotFound();
        }

        return Ok(product);
    }
    
    
    [HttpPost]
    public IActionResult Create(ProductForCreateDto dto)
    {
        var product = _service.CreateProduct(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = product.Id },
            product);
    }
    
    
    [HttpPut("{id}")]
    public IActionResult Update(int id, ProductForUpdateDto dto)
    {
        var product = _service.GetProductById(id);

        if (product is null)
        {
            return NotFound();
        }

        _service.UpdateProduct(id, dto);

        return NoContent();
    }
    
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = _service.GetProductById(id);

        if (product is null)
        {
            return NotFound();
        }

        _service.DeleteProduct(id);

        return NoContent();
    }
    
    
    [HttpGet("search")]
    public IActionResult Search([FromQuery] string name)
    {
        var products = _service.SearchProductsByName(name);

        return Ok(products);
    }
    
    
    [HttpGet("stats")]
    public IActionResult GetStats()
    {
        var stats = _service.GetStats();

        return Ok(stats);
    }
}