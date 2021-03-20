using System;
using TennisClub.Data.model;

namespace TennisClub.Data.dao.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IChildRepository ChildRepository { get; }
        IGroupRepository GroupRepository { get; }
        public void SaveChanges();
        public void Dispose();
    }
}