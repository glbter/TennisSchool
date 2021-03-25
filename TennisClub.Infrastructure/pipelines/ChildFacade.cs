﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.interfaces;
using TennisClub.Infrastructure.mappers;
using TennisClub.Infrastructure.services;

namespace TennisClub.Infrastructure.pipelines
{
    public class ChildFacade : IChildFacade
    {
        private readonly Predicate<Child> _isNotAdult;
        private readonly IGroupService _groupService;
        private readonly UnitOfWork _unitOfWork;
        private readonly ChildInDbNullableToChildMapper _fromDbNullableToChildMapper;

        public ChildFacade(IServiceProvider serviceProvider)
        {
            this._unitOfWork = serviceProvider.GetRequiredService<UnitOfWork>();
            _groupService = serviceProvider.GetRequiredService<IGroupService>();
            _isNotAdult = child => child.Age < 18;
            _fromDbNullableToChildMapper = new ChildInDbNullableToChildMapper();
        }

        public bool AddChild(Child child)
        {
            if (child?.FirstName == String.Empty || child?.LastName == String.Empty)
                return false;
            if (!_isNotAdult.Invoke(child)) return false;
            
            _groupService.AddChildToGroup(child);
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
