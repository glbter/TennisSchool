
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.dao
{
    public interface IDaoDelete<T>
    {
        public void Delete(T entity);
    }
}
