using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task CreateAsync(TI entity)
        {
            await _dbContext.AddAsync(entity);
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
        
        public async ValueTask<TO> FindByIdAsync(TK id)
        {
            return await _dbContext.FindAsync<TO>(id);
        }

         public abstract IList<TO> FindAll();
         public abstract Task<IList<TO>> FindAllAsync();
    }
}
