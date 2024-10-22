using SlopShop.Entities;
using SlopShop.Repositories;

namespace SlopShop.Services;

public class ProductsService
{
    private readonly ILogger<ProductsService> _logger;
    
    private readonly SlopShopDbContext _dbContext;
    
    public ProductsService(ILogger<ProductsService> logger, SlopShopDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public Product[] GetProducts(int page)
    {
        if (page < 1)
        {
            page = 1;
        }
        
        var products = _dbContext.Products.Skip(10 * (page - 1)).Take(10).ToList();
        
        _logger.LogInformation($"Fetching 10 values of page: {page}");
        
        return products.ToArray();
    }
}