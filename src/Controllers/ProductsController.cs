using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using SlopShop.Entities;
using SlopShop.Exceptions;
using SlopShop.Models.DTOs;
using SlopShop.Services;

namespace SlopShop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{

    private readonly ILogger<ProductsController> _logger;
    private readonly ProductsService _productsService;

    public ProductsController(ILogger<ProductsController> logger, ProductsService productsService)
    {
        _logger = logger;
        _productsService = productsService;
    }

    [HttpGet(Name = "GetAllProducts")]
    public Product[] GetAllProducts([FromQuery(Name = "page"), DefaultValue(1)] int page)
    {
        _logger.LogInformation("Hit GetAllProducts endpoint");
        return _productsService.GetProducts(page);
    }
    
    [HttpGet("{id:int}", Name = "GetProductById")]
    public async Task<ActionResult<Product>> GetProductById([FromRoute(Name = "id")] int id)
    {
        _logger.LogInformation("Hit GetProductById endpoint");
        try
        {
            return await _productsService.GetProductById(id).ConfigureAwait(false);
        }
        catch (ProductNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPost(Name = "CreateProduct")]
    public async Task<ActionResult<Product>> CreateProduct([FromBody] ProductDto productDto)
    {
        _logger.LogInformation("Hit CreateProduct endpoint");
        try
        {
            var product = await _productsService.CreateProduct(productDto);

            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        catch (ProductMutationException ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete("{id:int}", Name = "DeleteProduct")]
    public async Task<ActionResult<Product>> DeleteProduct([FromRoute(Name = "id")] int id)
    {
        _logger.LogInformation("Hit DeleteProduct endpoint");
        try
        {
            var product = await _productsService.DeleteProduct(id);

            return product;
        }
        catch (ProductNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPut("{id:int}", Name = "UpdateProduct")]
    public async Task<ActionResult<Product>> UpdateProduct([FromRoute(Name = "id")] int id, [FromBody] ProductDto productDto)
    {
        _logger.LogInformation("Hit UpdateProduct endpoint");
        try
        {
            var product = await _productsService.UpdateProduct(id, productDto);

            return product;
        }
        catch (ProductNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
