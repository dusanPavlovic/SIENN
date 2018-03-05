using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Type = SIENN.DbAccess.Entities.Type;

namespace SIENN.DbAccess.Repositories
{
    public class ProductRepository : GenericRepository<Product>
    {
        private readonly DbContext _context;
        private readonly DbSet<Type> _typeEntities;
        private readonly DbSet<Unit> _unitEntities;
        private readonly DbSet<Product> _productEntities;
        private readonly DbSet<ProductCategory> _productCategoriesEntites;

        public ProductRepository(DbContext context) : base(context)
        {
            _context = context;
            _typeEntities = context.Set<Type>();
            _unitEntities = context.Set<Unit>();
            _productEntities = context.Set<Product>();
            _productCategoriesEntites = context.Set<ProductCategory>();
        }

        public override Product Get(int id)
        {
            return _productEntities
                .Include(x => x.Unit)
                .Include(x => x.Type)
                .Include(x => x.ProductCategories)
                .FirstOrDefault(x => x.Code.Equals(id));
        }

        public override IEnumerable<Product> GetAll()
        {
            return _productEntities.Include(x => x.ProductCategories).ToList();
        }

        public override IEnumerable<Product> GetRange(int start, int count, Expression<Func<Product, bool>> predicate)
        {
            return _productEntities.Where(predicate).Skip(start).Take(count).Include(x => x.ProductCategories).ToList();
        }

        public override void Update(Product entity)
        {
            var productCategories = _productCategoriesEntites
                .Where(x => x.ProductCode.Equals(entity.Code))
                .ToList();

            var comparer = new ProductCategoryComparer();

            var toRemove = productCategories.Except(entity.ProductCategories, comparer).ToList();
            _productCategoriesEntites.RemoveRange(toRemove);

            var toAdd = entity.ProductCategories.Except(productCategories, comparer).ToList();
            _productCategoriesEntites.AddRange(toAdd);

            base.Update(entity);
        }
    }
}