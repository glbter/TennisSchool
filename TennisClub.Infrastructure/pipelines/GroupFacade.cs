using System;
using System.Collections.Generic;
using System.Linq;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.mappers;

namespace TennisClub.Infrastructure.pipelines
{
    public class GroupFacade
    {
        private readonly UnitOfWork unitOfWork;
        private readonly GroupInDbNullableToGroupMapper fromDbGroupMapper;
        
        public GroupFacade(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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