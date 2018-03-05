using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(DbContext context) : base(context)
        {
        }
    }
}