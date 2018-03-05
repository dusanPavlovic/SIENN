using ExpressMapper.Extensions;
using SIENN.DbAccess.Entities;
using SIENN.Services.Models;

namespace SIENN.Services.Adapters
{
    internal class TypeAdapter
    {
        public static TypeDto BuildTypeDto(Type type) => type.Map<Type, TypeDto>();

        public static Type BuildType(TypeDto typeDto) => typeDto.Map<TypeDto, Type>();
    }
}