using System.Collections.Generic;
using TennisClub.AppCore.Model.interfaces;

namespace TennisClub.Data.Repository.interfaces
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
