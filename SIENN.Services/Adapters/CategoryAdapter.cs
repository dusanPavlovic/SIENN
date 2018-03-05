using ExpressMapper.Extensions;
using SIENN.DbAccess.Entities;
using SIENN.Services.Models;

namespace SIENN.Services.Adapters
{
    internal class CategoryAdapter
    {
        public static CategoryDto BuildCategoryDto(Category category) => category.Map<Category, CategoryDto>();

        public static Category BuildCategory(CategoryDto categoryDto) => categoryDto.Map<CategoryDto, Category>();
    }
}