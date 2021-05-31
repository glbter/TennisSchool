using System.Collections.Generic;
using System.Threading.Tasks;
using TennisClub.AppCore.Model.impl;

namespace TennisClub.Infrastructure.Interfaces
{
    public interface IGroupAsyncService
    {
        public Task AddChildToGroupAsync(Child child, Group group);
        public Task<List<Group>> TryAddChildToGroupAsync(Child child);
    }
}