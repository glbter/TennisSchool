using System;
using System.Collections.Generic;

namespace TennisClub.Data.dao.interfaces
{
    public interface IDao<T>
    {
        public void Create(T entity);
        public T Get(Guid id);
        public List<T> GetAll();
    }
}
