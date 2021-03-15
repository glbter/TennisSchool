using System;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.dao;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.model;
using TennisClub.Infrastructure.interfaces;
using TennisClub.Infrastructure.mappers;


namespace TennisClub.Infrastructure.services
{
    public class ChildService : IChildService<Guid>
    {
        private readonly UnitOfWork unitOfWork;
        private readonly IMapper<Child, ChildInDb> childMapperToDb;
        public ChildService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.childMapperToDb = new ChildToChildInDbMapper();
        }

        public void SetChildToGroup(Child child, Group group)
        {
            child.GroupId = group.Id;
            unitOfWork.ChildRepository.Create(
                childMapperToDb.Map(child));
        }
    }
}
