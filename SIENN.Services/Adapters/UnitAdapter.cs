using ExpressMapper.Extensions;
using SIENN.DbAccess.Entities;
using SIENN.Services.Models;

namespace SIENN.Services.Adapters
{
    internal class UnitAdapter
    {
        public static Unit BuildUnit(UnitDto unitDto) => unitDto.Map<UnitDto, Unit>();

        public static UnitDto BuilUnitDto(Unit unit) => unit.Map<Unit, UnitDto>();
    }
}