using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public void Update(T group)
        {
            Delete(group);
            Create(group);
        }

        public void Delete(T group)
        {
            Entities.RemoveAll(it => group.Id.Equals(it.Id));
        }
        
        public void Delete(TK id)
        {
            Entities.RemoveAll(it => it.Id.Equals(id));
        }

        public T FindById(TK id)
        {
            return Entities.Find((T entity) => entity.Id.Equals(id));
        }

        public List<T> FindAll(IQueryable<T> query = null)
        {
            return Entities.ToList(); //Entities;
        }

    }
}
