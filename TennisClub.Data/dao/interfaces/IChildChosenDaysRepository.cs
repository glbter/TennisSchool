using System;
using System.Collections.Generic;
using TennisClub.Data.model;

namespace TennisClub.Data.dao.interfaces
{
    public interface IChildChosenDaysRepository : IRepository<ChildChosenDaysEntity, ChildChosenDaysEntity, Guid>
    {
        public void BulkInsert(IList<ChildChosenDaysEntity> days);
    }
}