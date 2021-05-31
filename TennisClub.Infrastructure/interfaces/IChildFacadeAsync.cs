using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TennisClub.AppCore.Model.impl;

namespace TennisClub.Infrastructure.Interfaces
{
    public interface IChildFacadeAsync
    {
        public Task<List<Group>> AddChildAsync(Child child);
        public Task<bool> AddChildWithChosenGroupAsync(Child child, Group group);
        public Task<Child> FindChildAsync(Guid id);
        public Task<List<Child>> GetAllAsync();
    }
}