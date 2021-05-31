using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TennisClub.Data.Context;
using TennisClub.Data.Model;
using TennisClub.Data.Repository.interfaces;

namespace TennisClub.Data.Repository
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
        
        public override async Task<IList<ChildInDb>> FindAllAsync()
        {
            return await _dbContext.ChildDbSet.ToListAsync();
        }
    }
}