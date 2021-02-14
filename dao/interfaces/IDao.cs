using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.dao
{
    public interface IDao<T>
    {
        public void Create(T entity);
        public T Get(Guid id);
        public List<T> GetAll();
    }
}
