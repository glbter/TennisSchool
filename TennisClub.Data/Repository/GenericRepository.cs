using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TennisClub.AppCore.Model.interfaces;
using TennisClub.Data.Repository.interfaces;

namespace TennisClub.Data.Repository
{
    public abstract class GenericRepository<TI, TO, TK> : IRepository<TI, TO, TK>
        where TO : class, IBaseId<TK> 
        where TI : IBaseId<TK>
    {
        private readonly DbContext _dbContext;

        protected GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Create(TI entity)
        {
            _dbContext.Add(entity);
        }

        public void Update(TI entity)
        {
            _dbContext.Update(entity);
        }

        public void Delete(TI entity)
        {
            _dbContext.Remove(entity);
        }

        public void Delete(TK id)
        {
            _dbContext.Remove(id);
        }

        public TO FindById(TK id)
        {
            return _dbContext.Find<TO>(id);
        }

         public abstract IList<TO> FindAll();
    }
}
