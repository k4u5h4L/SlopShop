using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using SlopShop.Entities;
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

    [HttpGet(Name = "GetProducts")]
    public Product[] Get([FromQuery(Name = "page"), DefaultValue(1)] int page)
    {
        _logger.LogInformation("Hit GetProducts endpoint");
        return _productsService.GetProducts(page);
    }
}
