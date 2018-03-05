using ExpressMapper;
using SIENN.DbAccess.Entities;
using SIENN.Services.Models;
using System.Linq;
using Type = SIENN.DbAccess.Entities.Type;

namespace SIENN.Services
{
    public class MappingRegistration
    {
        public static void Register()
        {
            Mapper.Register<Type, TypeDto>();
            Mapper.Register<TypeDto, Type>();

            Mapper.Register<Unit, UnitDto>();
            Mapper.Register<UnitDto, Unit>();

            Mapper.Register<Category, CategoryDto>();
            Mapper.Register<CategoryDto, Category>();

            Mapper.Register<ProductDto, Product>();
            Mapper.Register<Product, ProductDto>()
                .Member(dest => dest.Categories, src => src.ProductCategories.Select(x => x.CategoryCode));
        }
    }
}