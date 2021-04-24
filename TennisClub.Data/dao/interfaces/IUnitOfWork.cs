using System;
using TennisClub.Data.model;

namespace TennisClub.Data.dao.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IChildRepository ChildRepository { get; }
        IGroupRepository GroupRepository { get; }
        IChildChosenDaysRepository ChildChosenDaysRepository { get; }
        public void SaveChanges();
        public new void Dispose();
    }
}