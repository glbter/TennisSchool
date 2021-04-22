using System;
using System.Linq;
using System.Threading.Tasks.Dataflow;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.dao;
using TennisClub.Data.model;
using TennisClub.Infrastructure.interfaces;
using TennisClub.Infrastructure.mappers;


namespace TennisClub.Infrastructure.services
{
    public class ChildService : IChildService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper<Child, ChildInDb> childMapperToDb;
        private readonly IMapper<Group, GroupInDb> groupMapperToDb;
        public ChildService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.childMapperToDb = new ChildToChildInDbMapper();
            this.groupMapperToDb = new GroupToGroupInDbMapper();
        }

        public void SetChildToGroup(Child child, Group group)
        {
            child.GroupId = group.Id;
            AddChild(child);
            group.ChildrenAmount += 1;
            unitOfWork.GroupRepository
                .Update(
                groupMapperToDb.Map(group));
        }

        public void AddChild(Child child)
        {
            unitOfWork.ChildRepository.Create(
                childMapperToDb.Map(child));
            var days = child.PreferableDays
                .Select(it => ToChildDay(child, it))
                .ToList();
            unitOfWork.ChildChosenDaysRepository
                .BulkInsert(days);
        }

        private ChildChosenDaysEntity ToChildDay(Child child, DayOfWeek day)
        {
            return new ChildChosenDaysEntity(child.Id, day);
        }
    }
}
