using System;
using System.Linq;
using System.Threading.Tasks;
using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Repository.interfaces;
using TennisClub.Infrastructure.Interfaces;
using TennisClub.Infrastructure.Mappers;

namespace TennisClub.Infrastructure.Services
{
    public class ChildAsyncService : IChildAsyncService
    { 
        private readonly IUnitOfWork unitOfWork;
        public ChildAsyncService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task SetChildToGroupAsync(Child child, Group group)
        {
            child.GroupId = group.Id;
            Task childTask = AddChildAsync(child);
            Task groupTask = IncrementChildAmountInGroupAsync(group);
            await Task.WhenAll(childTask, groupTask);
        }

        public async Task AddChildAsync(Child child)
        {
            Task createTask = unitOfWork.ChildRepository
                .CreateAsync(new ChildToChildInDbMapper().Map(child));
            
            var days = child.PreferableDays
                .Select(it => new ToChildDayMapper().Map(child, it))
                .ToList();
            
            Task bulkInsertTask = unitOfWork.ChildChosenDaysRepository
                .BulkInsertAsync(days);

            await Task.WhenAll(createTask, bulkInsertTask);
        }

        private async Task IncrementChildAmountInGroupAsync(Group group)
        {
            var grp = await unitOfWork.GroupRepository.FindByIdAsync(group.Id);
            grp.ChildrenAmount += 1;
            unitOfWork.GroupRepository.Update(grp);
        }
    }
}