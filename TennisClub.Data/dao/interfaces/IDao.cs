using System;
using System.Collections.Generic;

namespace TennisClub.Data.dao.interfaces
{
    public interface IDao<T, in TK>
    {
        public void Create(T entity);
        public T Get(TK id);
        public List<T> GetAll();
    }
}
