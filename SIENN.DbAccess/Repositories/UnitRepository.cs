using Microsoft.EntityFrameworkCore;
using SIENN.DbAccess.Entities;

namespace SIENN.DbAccess.Repositories
{
    public class UnitRepository : GenericRepository<Unit>
    {
        public UnitRepository(DbContext context) : base(context)
        {
        }
    }
}