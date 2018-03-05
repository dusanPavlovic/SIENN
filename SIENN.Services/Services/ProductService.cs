using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories;
using SIENN.Services.Adapters;
using SIENN.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace SIENN.Services.Services
{
    public class ProductService : IGenericService<ProductDto>, IProductService
    {
        private readonly IGenericRepository<Product> _repository;

        public ProductService(IGenericRepository<Product> repository)
        {
            _repository = repository;
        }

        public void Add(ProductDto entity)
        {
            var adapter = ProductAdapter.BuildProduct(entity);
            _repository.Add(adapter);
            entity.Code = adapter.Code;
        }

        public void Edit(ProductDto entity)
        {
            _repository.Update(ProductAdapter.BuildProduct(entity));
        }

        public ProductDto Get(int id)
        {
            return ProductAdapter.BuildProductDto(_repository.Get(id));
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return _repository.GetAll().Select(ProductAdapter.BuildProductDto);
        }

        public IEnumerable<ProductDto> GetAvailableProducts(int start, int count)
        {
            return _repository.GetRange(start, count, x => x.IsAvailable).Select(ProductAdapter.BuildProductDto);
        }

        public IEnumerable<ProductDto> GetFilteredProducts(int? category, int? type, int? unit)
        {
            return _repository.GetAll()
                .Where(x => type == null || x.TypeCode.Equals(type))
                .Where(x => unit == null || x.UnitCode.Equals(unit))
                .Where(x => category == null || x.ProductCategories.Any(y => y.CategoryCode.Equals(category) && y.ProductCode.Equals(x.Code)))
                .Select(ProductAdapter.BuildProductDto);
        }

        public ProductInfoDto GetProductInfo(int code)
        {
            return ProductAdapter.BuildProductInfoDto(_repository.Get(code));
        }

        public void Remove(int id)
        {
            var entity = _repository.Get(id);
            if (entity != null)
            {
                _repository.Remove(entity);
            }
        }
    }
}