using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.model;
using TennisClub.Infrastructure.interfaces;
using TennisClub.Infrastructure.mappers;

namespace TennisClub.Infrastructure.pipelines
{
    public class ChildFacade : IChildFacade
    {
        private readonly Predicate<Child> _isNotAdult;
        private readonly IGroupService _groupService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<ChildInDb, Child> _fromDbNullableToChildMapper;

        public ChildFacade(IServiceProvider serviceProvider)
        {
            this._unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _groupService = serviceProvider.GetRequiredService<IGroupService>();
            _isNotAdult = child => child.Age < 18;
            _fromDbNullableToChildMapper = new ChildInDbNullableToChildMapper();
        }

        public List<Group> AddChild(Child child)
        {
            if (child?.FirstName == string.Empty || child?.LastName == string.Empty)
                return null;
            if (!_isNotAdult.Invoke(child)) return null;
            
            return  _groupService.TryAddChildToGroup(child);
        }
        
        public bool AddChildWithChosenGroup(Child child, Group group)
        {
            if (child == null || group == null)
                return false;
            _groupService.AddChildToGroup(child, group);
            return true;
        }

        public Child FindChild(Guid id)
        {
            return id == Guid.Empty ? null : _fromDbNullableToChildMapper.Map(
                _unitOfWork.ChildRepository.FindById(id));
        }

        public List<Child> GetAll()
        {
            return _unitOfWork.ChildRepository.FindAll()
                .Select(_fromDbNullableToChildMapper.Map)
                .ToList();
        }
    }
}
