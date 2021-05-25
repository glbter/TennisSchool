using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TennisClub.Data.Context;
using TennisClub.Data.Model;
using TennisClub.Data.Repository.interfaces;

namespace TennisClub.Data.Repository
{
    public class ChildChosenDaysRepository : GenericRepository<ChildChosenDaysEntity, ChildChosenDaysEntity, Guid>, IChildChosenDaysRepository
    {
        private readonly TennisClubContext _dbContext;
        public ChildChosenDaysRepository(TennisClubContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void BulkInsert(IList<ChildChosenDaysEntity> days)
        {
            _dbContext.AddRange(days);
        } 
        
        public async Task BulkInsertAsync(IList<ChildChosenDaysEntity> days)
        {
            await _dbContext.AddRangeAsync(days);
        } 
        
        public override IList<ChildChosenDaysEntity> FindAll()
        {
            return _dbContext.ChildChosenDaysDbSet.ToList();
        }


    }
}