using System;
using System.Collections.Generic;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.dao.interfaces;

namespace TennisClub.Data.dao
{
    class Dao<T> : IDao<T> where T : IBaseId
    {
        protected List<T> entities;
        public void Create(T entity)
        {
            entities.Add(entity);
        }

        public T Get(Guid id)
        {
            return entities.Find((T entity) => entity.Id.Equals(id));
        }

        public List<T> GetAll()
        {
            return entities;
        }
    }
}
