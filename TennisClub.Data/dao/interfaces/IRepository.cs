using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Data.dao.interfaces
{
    public interface IRepository<in TI, TO, in TK> where TO : class
    {
        void Create(TI entity);
        void Update(TI entity);
        void Delete(TI entity);
        void Delete(TK id);
        TO FindById(TK id);
        IList<TO> FindAll();

    }
}
