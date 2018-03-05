using Microsoft.EntityFrameworkCore;
using Type = SIENN.DbAccess.Entities.Type;

namespace SIENN.DbAccess.Repositories
{
    public class TypeRepository : GenericRepository<Type>
    {
        public TypeRepository(DbContext context) : base(context)
        {
        }
    }
}