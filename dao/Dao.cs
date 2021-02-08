using Lab1.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.dao
{
    public class Dao<T> : IDao<T> where T : Base
    {
        private List<T> _entities;
        public void Create(T entity)
        {
            _entities.Add(entity);
        }

        /*public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public void Update(T entity)
        {
            Delete(entity);
            Create(entity);
        }*/

        public T Get(Guid id)
        {
            return _entities.Find((T entity) => entity.Id.Equals(id));
        }

        public List<T> GetAll()
        {
            return _entities;
        }
    }
}
