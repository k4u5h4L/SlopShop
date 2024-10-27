using SlopShop.Entities;
using SlopShop.Exceptions;
using SlopShop.Models.DTOs;
using SlopShop.Repositories;
using SlopShop.Utilities;

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
        page = GenericUtils.GetPageNumber(page);
        
        var products = _dbContext.Products.Skip(10 * (page - 1)).Take(10).ToList();
        
        _logger.LogInformation($"Fetching 10 values of page: {page}");
        
        return products.ToArray();
    }
    
    public async ValueTask<Product> GetProductById(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);

        if (product == null)
        {
            _logger.LogError($"Product with id: {id} was not found");
            throw new ProductNotFoundException($"Product with id: {id} was not found");
        }
        
        _logger.LogInformation($"Fetching product with ID: {id}");
        
        return product;
    }

    public async ValueTask<Product> CreateProduct(ProductDto productDto)
    {
        var product = new Product(productDto);

        try
        {
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to create product: {ex.Message}");
            throw new ProductMutationException($"Unable to create product");
        }

        return product;
    }
    
    public async ValueTask<Product> DeleteProduct(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);

        if (product == null)
        {
            _logger.LogError($"Product with id: {id} was not found");
            throw new ProductNotFoundException($"Product with id: {id} was not found");
        }

        try
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to delete product: {ex.Message}");
            throw new ProductMutationException($"Unable to delete product");
        }

        return product;
    }
    
    public async ValueTask<Product> UpdateProduct(int id, ProductDto productDto)
    {
        var product = await _dbContext.Products.FindAsync(id);

        if (product == null)
        {
            _logger.LogError($"Product with id: {id} was not found");
            throw new ProductNotFoundException($"Product with id: {id} was not found");
        }

        try
        {
            product.Update(productDto);
            _dbContext.Products.Update(product);
            await _dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError($"Failed to update product: {ex.Message}");
            throw new ProductMutationException($"Unable to update product");
        }

        return product;
    }
}