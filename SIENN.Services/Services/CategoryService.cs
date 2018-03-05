using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories;
using SIENN.Services.Adapters;
using SIENN.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace SIENN.Services.Services
{
    public class CategoryService : IGenericService<CategoryDto>
    {
        private readonly IGenericRepository<Category> _repository;

        public CategoryService(IGenericRepository<Category> repository)
        {
            _repository = repository;
        }

        public void Add(CategoryDto entity)
        {
            var adapter = CategoryAdapter.BuildCategory(entity);
            _repository.Add(adapter);
            entity.Code = adapter.Code;
        }

        public void Edit(CategoryDto entity)
        {
            _repository.Update(CategoryAdapter.BuildCategory(entity));
        }

        public CategoryDto Get(int id)
        {
            return CategoryAdapter.BuildCategoryDto(_repository.Get(id));
        }

        public IEnumerable<CategoryDto> GetAll()
        {
            return _repository.GetAll().Select(CategoryAdapter.BuildCategoryDto);
        }

        public void Remove(int id)
        {
            var entity = _repository.Get(id);
            if (entity != null) _repository.Remove(entity);
        }
    }
}