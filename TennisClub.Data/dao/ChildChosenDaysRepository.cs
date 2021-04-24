using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TennisClub.Data.context;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.model;

namespace TennisClub.Data.dao
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
        
        public override IList<ChildChosenDaysEntity> FindAll()
        {
            return _dbContext.ChildChosenDaysDbSet.ToList();
        }


    }
}