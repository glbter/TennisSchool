using System;
using System.Configuration;
using TennisClub.AppCore.interfaces;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.AppCore.validators;
using TennisClub.Data.dao;
using TennisClub.Data.model;
using TennisClub.Infrastructure.interfaces;
using TennisClub.Infrastructure.mappers;

namespace TennisClub.Infrastructure.services
{
    public class GroupService : IGroupService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IChildService<Guid> childService;
        private readonly IMapper<Group, GroupInDb> groupMapperToDb;
        private readonly IMapper<GroupInDb, Group> groupMapperFromDb;
        private readonly ChildAgeRuleChecker ageRuleChecker;
        private readonly int maxChildren;
        
        public GroupService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.childService = new ChildService(unitOfWork);
            
            this.groupMapperToDb = new GroupToGroupInDbMapper();
            this.groupMapperFromDb = new GroupInDbNullableToGroupMapper();
            
            this.ageRuleChecker = new ChildAgeRuleChecker();
            this.maxChildren = Convert.ToInt32(
                ConfigurationManager.AppSettings["maxAmountOfChildrenInGroup"] ?? "5");
        }

        public void AddChildToGroup(Child child)
        {
            Group group = groupMapperFromDb.Map(
                unitOfWork.GroupRepository.FindVacantGroup(
                    child.PreferableDay,
                    child.GameLevel,
                    amount => amount < maxChildren,
                    ageRuleChecker.CreateRuleCheckerDelegate((Child) child)));
            if (group == null)
            {
                group = new Group(child.GameLevel, child.PreferableDay);
                unitOfWork.GroupRepository.Create(
                    groupMapperToDb.Map(group));
            }
            childService.SetChildToGroup(child, group);
            unitOfWork.SaveChanges();
        }
    }
}
