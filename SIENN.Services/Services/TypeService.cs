using SIENN.DbAccess.Repositories;
using SIENN.Services.Adapters;
using SIENN.Services.Models;
using System.Collections.Generic;
using System.Linq;
using Type = SIENN.DbAccess.Entities.Type;

namespace SIENN.Services.Services
{
    public class TypeService : IGenericService<TypeDto>
    {
        private readonly IGenericRepository<Type> _repository;

        public TypeService(IGenericRepository<Type> repository)
        {
            _repository = repository;
        }

        public void Add(TypeDto entity)
        {
            var adapter = TypeAdapter.BuildType(entity);
            _repository.Add(adapter);
            entity.Code = adapter.Code;
        }

        public void Edit(TypeDto entity)
        {
            _repository.Update(TypeAdapter.BuildType(entity));
        }

        public TypeDto Get(int id)
        {
            return TypeAdapter.BuildTypeDto(_repository.Get(id));
        }

        public IEnumerable<TypeDto> GetAll()
        {
            return _repository.GetAll().Select(TypeAdapter.BuildTypeDto);
        }

        public void Remove(int id)
        {
            var entity = _repository.Get(id);
            if (entity != null)
            {
                _repository.Remove(entity);
            }
        }
    }
}