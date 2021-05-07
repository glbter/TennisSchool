using System;
using System.Collections.Generic;
using System.Linq;
using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Model;
using TennisClub.Data.Repository.interfaces;
using TennisClub.Infrastructure.Interfaces;
using TennisClub.Infrastructure.Mappers;

namespace TennisClub.Infrastructure.Pipelines
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