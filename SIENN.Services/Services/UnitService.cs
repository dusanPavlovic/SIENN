using SIENN.DbAccess.Entities;
using SIENN.DbAccess.Repositories;
using SIENN.Services.Adapters;
using SIENN.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace SIENN.Services.Services
{
    public class UnitService : IGenericService<UnitDto>
    {
        private readonly IGenericRepository<Unit> _repository;

        public UnitService(IGenericRepository<Unit> repository)
        {
            _repository = repository;
        }

        public void Add(UnitDto entity)
        {
            var adapter = UnitAdapter.BuildUnit(entity);
            _repository.Add(adapter);
            entity.Code = adapter.Code;
        }

        public void Edit(UnitDto entity)
        {
            _repository.Update(UnitAdapter.BuildUnit(entity));
        }

        public UnitDto Get(int id)
        {
            return UnitAdapter.BuilUnitDto(_repository.Get(id));
        }

        public IEnumerable<UnitDto> GetAll()
        {
            return _repository.GetAll().Select(UnitAdapter.BuilUnitDto);
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