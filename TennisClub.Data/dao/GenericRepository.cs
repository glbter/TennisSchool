using System.Collections.Generic;
using System.Data.Entity;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.context;
using TennisClub.Data.dao.interfaces;

namespace TennisClub.Data.dao
{
    public abstract class GenericRepository<TI, TO, TK>  : IRepository<TI, TO, TK> where TO : class
    {
        private readonly DbContext _dbContext;

        protected GenericRepository(PostgresDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public abstract void Create(TI entity);
        public abstract void Update(TI entity);
        public abstract void Delete(TI entity);
        public abstract void Delete(TK id);
        public abstract TO FindById(TK id);
        public abstract IList<TO> FindAll();
         
        protected class Entity: IBaseId<TK>
        {
         public TK Id { get; }
         public Entity(TK id) { Id = id; }
        }
    }
}
