using System;
using TennisClub.Data.Model;

namespace TennisClub.Data.Repository.interfaces
{
    public interface IChildRepository : IRepository<ChildInDb, ChildInDb, Guid>
    {
        
    }
}