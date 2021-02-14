using Lab1.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.dao
{
    public class Dao<T> : IDao<T> where T : IBaseId
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
