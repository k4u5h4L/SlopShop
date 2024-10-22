using Microsoft.AspNetCore.Mvc;

namespace SlopShop.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{

    private readonly ILogger<ProductsController> _logger;

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetProducts")]
    public string[] Get()
    {
        _logger.LogInformation("GetProducts");
        return ["hello", "there"];
    }
}
