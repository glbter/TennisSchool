using System;
using System.Collections.Generic;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.dao.interfaces;

namespace TennisClub.Data.dao
{
    class Dao<T, TK> : IDao<T, TK> where T : IBaseId<TK>
    {
        protected readonly List<T> Entities = new List<T>();
        public void Create(T entity)
        {
            Entities.Add(entity);
        }

        public T Get(TK id)
        {
            return Entities.Find((T entity) => entity.Id.Equals(id));
        }

        public List<T> GetAll()
        {
            return Entities;
        }
    }
}
