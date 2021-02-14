using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.dao
{
    public interface IDaoUpdate<T>
    {
        public void Update(T entity);
    }
}
