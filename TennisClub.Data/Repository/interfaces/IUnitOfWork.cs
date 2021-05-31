using System;
using System.Threading.Tasks;

namespace TennisClub.Data.Repository.interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IChildRepository ChildRepository { get; }
        IGroupRepository GroupRepository { get; }
        IChildChosenDaysRepository ChildChosenDaysRepository { get; }
        public void SaveChanges();
        public Task SaveChangesAsync();
        public new void Dispose();
    }
}