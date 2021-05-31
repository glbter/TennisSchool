using System;
using System.Linq;
using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Model;
using TennisClub.Data.Repository.interfaces;
using TennisClub.Infrastructure.Interfaces;
using TennisClub.Infrastructure.Mappers;

namespace TennisClub.Infrastructure.Services
{
    public class ChildService : IChildService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper<Child, ChildInDb> childMapperToDb;
        private readonly IMapper<Group, GroupInDb> groupMapperToDb;
        public ChildService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.childMapperToDb = new ChildToChildInDbMapper();
            this.groupMapperToDb = new GroupToGroupInDbMapper();
        }

        public void SetChildToGroup(Child child, Group group)
        {
            child.GroupId = group.Id;
            AddChild(child);
            IncrementChildAmountInGroup(group);
        }

        public void AddChild(Child child)
        {
            unitOfWork.ChildRepository.Create(
                childMapperToDb.Map(child));
            var days = child.PreferableDays
                .Select(it => new ToChildDayMapper().Map(child, it))
                .ToList();
            unitOfWork.ChildChosenDaysRepository
                .BulkInsert(days);
        }

        private void IncrementChildAmountInGroup(Group group)
        {
            var grp = unitOfWork.GroupRepository.FindById(group.Id);
            grp.ChildrenAmount += 1;
            unitOfWork.GroupRepository.Update(grp);
        }
    }
}
