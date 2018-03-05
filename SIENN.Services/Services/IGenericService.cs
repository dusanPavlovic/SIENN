using System.Collections.Generic;

namespace SIENN.Services.Services
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        IEnumerable<TEntity> GetAll();

        void Add(TEntity entity);

        void Remove(int id);

        void Edit(TEntity entity);
    }
}