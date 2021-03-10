using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace TennisClub.Data.dao.interfaces
{
    public interface IDao<T, in TK>
    {
        public void Create(T entity);
        public void Update(T entity);
        public void Delete(T entity);
        public void Delete(TK id);
        public T FindById(TK id);
        public List<T> FindAll(IQueryable<T> query = null);

    }
}
