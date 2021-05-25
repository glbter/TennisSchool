using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TennisClub.Data.Model;

namespace TennisClub.Data.Repository.interfaces
{
    public interface IChildChosenDaysRepository : IRepository<ChildChosenDaysEntity, ChildChosenDaysEntity, Guid>
    {
        public void BulkInsert(IList<ChildChosenDaysEntity> days);
        public Task BulkInsertAsync(IList<ChildChosenDaysEntity> days);
    }
}