using System.Threading.Tasks;
using TennisClub.AppCore.Model.impl;

namespace TennisClub.Infrastructure.Interfaces
{
    public interface IChildAsyncService
    {
        public Task SetChildToGroupAsync(Child child, Group group);
        public Task AddChildAsync(Child child);
    }
}