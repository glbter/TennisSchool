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
        private readonly TennisClubContext _dbContext;
        
        public ChildRepository(TennisClubContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public override IList<ChildInDb> FindAll()
        {
            return _dbContext.ChildDbSet.ToList();
        }
    }
}