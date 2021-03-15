using System;
using TennisClub.Data.model;

namespace TennisClub.Data.dao.interfaces
{
    public interface IChildRepository : IRepository<ChildInDb, ChildInDb, Guid>
    {
        
    }
}