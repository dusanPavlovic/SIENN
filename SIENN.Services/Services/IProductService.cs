using SIENN.Services.Models;
using System.Collections.Generic;

namespace SIENN.Services.Services
{
    public interface IProductService
    {
        ProductInfoDto GetProductInfo(int code);

        IEnumerable<ProductDto> GetFilteredProducts(int? category, int? type, int? unit);

        IEnumerable<ProductDto> GetAvailableProducts(int start, int count);
    }
}