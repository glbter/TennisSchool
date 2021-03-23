using System;
using System.Collections.Generic;
using System.Linq;
using TennisClub.Data.model;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.context;

namespace TennisClub.Data.dao
{
    public class ChildRepository : GenericRepository<ChildInDb, ChildInDb, Guid>, IChildRepository
    {
        private readonly PostgresDbContext _dbContext;

        public ChildRepository(PostgresDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public override IList<ChildInDb> FindAll()
        {
            return _dbContext.ChildDbSet.ToList();
        }
        
        public override void Create(ChildInDb entity)
        {
            _dbContext.ChildDbSet.Add(entity);
        }

        public override void Update(ChildInDb entity)
        {
            _dbContext.ChildDbSet.Remove(entity);
            _dbContext.ChildDbSet.Add(entity);
        }

        public override void Delete(ChildInDb entity)
        {
            _dbContext.ChildDbSet.Remove(entity);
        }

        public override void Delete(Guid id)
        {
            _dbContext.ChildDbSet.Remove(new ChildInDb(){ Id = id});
        }

        public override ChildInDb FindById(Guid id)
        {
            return _dbContext.ChildDbSet.Find(id);
        }
    }
}