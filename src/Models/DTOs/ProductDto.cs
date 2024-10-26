namespace SlopShop.Models.DTOs;

public class ProductDto
{
    public ProductDto(string? name, string? category, string? subCategory, string? brand, int? salePrice, int? marketPrice, string? type, decimal? rating, string? description)
    {
        Name = name;
        Category = category;
        SubCategory = subCategory;
        Brand = brand;
        SalePrice = salePrice;
        MarketPrice = marketPrice;
        Type = type;
        Rating = rating;
        Description = description;
    }
    
    public string? Name { get; set; }

    public string? Category { get; set; }

    public string? SubCategory { get; set; }

    public string? Brand { get; set; }

    public int? SalePrice { get; set; }

    public int? MarketPrice { get; set; }

    public string? Type { get; set; }

    public decimal? Rating { get; set; }

    public string? Description { get; set; }
}