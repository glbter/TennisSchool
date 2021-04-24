using System;
using System.Collections.Generic;
using System.Linq;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.model;
using TennisClub.Infrastructure.interfaces;
using TennisClub.Infrastructure.mappers;

namespace TennisClub.Infrastructure.pipelines
{
    public class GroupFacade : IGroupFacade
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper<GroupInDb, Group> fromDbGroupMapper;
        
        public GroupFacade(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            fromDbGroupMapper = new GroupInDbNullableToGroupMapper();
        }

        public Group FindGroup(Guid id)
        {
            return id == Guid.Empty ? null : fromDbGroupMapper.Map(
                unitOfWork.GroupRepository.FindById(id));
        }

        public List<Group> GetAll()
        {
            return unitOfWork.GroupRepository.FindAll()
                .Select(fromDbGroupMapper.Map)
                .ToList();
        }
    }
}