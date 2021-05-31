using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Model;
using TennisClub.Data.Repository.interfaces;
using TennisClub.Infrastructure.Interfaces;
using TennisClub.Infrastructure.Mappers;

namespace TennisClub.Infrastructure.Pipelines
{
    public class ChildFacadeAsync : IChildFacadeAsync
    {
        private readonly Predicate<Child> _isNotAdult;
        private readonly IGroupAsyncService _groupService;
        private readonly IUnitOfWork _unitOfWork;

        public ChildFacadeAsync(IServiceProvider serviceProvider)
        {
            this._unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _groupService = serviceProvider.GetRequiredService<IGroupAsyncService>();
            _isNotAdult = child => child.Age < 18;
        }

        public async Task<List<Group>> AddChildAsync(Child child)
        {
            if (child?.FirstName == string.Empty || child?.LastName == string.Empty)
                return null;
            if (!_isNotAdult.Invoke(child)) return null;

            return await _groupService.TryAddChildToGroupAsync(child);
        }

        public async Task<bool> AddChildWithChosenGroupAsync(Child child, Group group)
        {
            if (child == null || group == null)
                return false;
            await _groupService.AddChildToGroupAsync(child, group);
            return true;
        }

        public async Task<Child> FindChildAsync(Guid id)
        {
            return id == Guid.Empty
                ? null
                : new ChildInDbNullableToChildMapper().Map(
                    await _unitOfWork.ChildRepository.FindByIdAsync(id));
        }

        public async Task<List<Child>> GetAllAsync()
        {
            IList<ChildInDb> children = await _unitOfWork.ChildRepository.FindAllAsync();
            return children
                .Select(new ChildInDbNullableToChildMapper().Map)
                .ToList();
        }
    }
}