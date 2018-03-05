using ExpressMapper.Extensions;
using SIENN.DbAccess.Entities;
using SIENN.Services.Models;
using System.Linq;

namespace SIENN.Services.Adapters
{
    internal class ProductAdapter
    {
        public static ProductDto BuildProductDto(Product product) => product.Map<Product, ProductDto>();

        public static Product BuildProduct(ProductDto productDto)
        {
            var product = productDto.Map<ProductDto, Product>();
            product.ProductCategories = productDto.Categories
                .Select(x => new ProductCategory() { CategoryCode = x, ProductCode = product.Code })
                .ToList();
            return product;
        }

        public static ProductInfoDto BuildProductInfoDto(Product product)
        {
            return new ProductInfoDto
            {
                ProductDescription = $"({product.Code}) {product.Description}",
                Price = $"{product.Price:##.##} zł",
                IsAvailable = product.IsAvailable ? "Available" : "Unavailable",
                DeliveryDate = $"{product.DeliveryDate.Day}.{product.DeliveryDate.Month}.{product.DeliveryDate.Year}",
                CategoriesCount = product.ProductCategories.Count,
                Type = $"({product.Type.Code}) {product.Type.Description}",
                Unit = $"({product.Unit.Code}) {product.Unit.Description}"
            };
        }
    }
}