using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TennisClub.AppCore.model.interfaces;

namespace TennisClub.Data.dao.interfaces
{
    public interface IRepository<in TI, TO, in TK>         
        where TO : class, IBaseId<TK> 
        where TI : IBaseId<TK>
    {
        public void Create(TI entity);
        public void Update(TI entity);
        public void Delete(TI entity);
        public void Delete(TK id);
        public TO FindById(TK id);
        public IList<TO> FindAll();
    }
}
