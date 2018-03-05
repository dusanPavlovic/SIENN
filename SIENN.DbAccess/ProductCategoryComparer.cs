using SIENN.DbAccess.Entities;
using System.Collections.Generic;

namespace SIENN.DbAccess
{
    internal class ProductCategoryComparer : IEqualityComparer<ProductCategory>
    {
        public bool Equals(ProductCategory x, ProductCategory y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (x is null || y is null) return false;
            return x.ProductCode == y.ProductCode && x.CategoryCode == y.CategoryCode;
        }

        public int GetHashCode(ProductCategory obj)
        {
            if (obj is null) return 0;
            return obj.CategoryCode.GetHashCode() ^ obj.ProductCode.GetHashCode();
        }
    }
}