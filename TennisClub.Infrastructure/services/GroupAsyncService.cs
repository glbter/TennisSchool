using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using TennisClub.AppCore.Model.impl;
using TennisClub.AppCore.Validators;
using TennisClub.Data.Model;
using TennisClub.Data.Repository.interfaces;
using TennisClub.Infrastructure.Interfaces;
using TennisClub.Infrastructure.Mappers;

namespace TennisClub.Infrastructure.Services
{
    public class GroupAsyncService : IGroupAsyncService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IChildAsyncService childService;
        private readonly int maxChildren;
        
        public GroupAsyncService(IServiceProvider serviceProvider)
        {
            this.unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            this.childService = serviceProvider.GetRequiredService<IChildAsyncService>();
            this.maxChildren = Convert.ToInt32(
                ConfigurationManager.AppSettings["maxAmountOfChildrenInGroup"] ?? "5");
        }

        public async Task<List<Group>> TryAddChildToGroupAsync(Child child)
        {
            List<Group> groups = await FindVaccantGroupsAsync(child);
            if (groups.Count <= 1)
            {
                Group group = groups.FirstOrDefault() 
                              ?? CreateGroup(child.GameLevel, child.LessonsDay);
                
                if (groups.Count == 0) await ChooseDayAsync(child, group);
                await unitOfWork.SaveChangesAsync();
                await AddChildToGroupAsync(child, group);
                groups = new List<Group> {group};
            }
            return groups;
        }

        public async Task AddChildToGroupAsync(Child child, Group group)
        {
            child.LessonsDay = group.LessonsDay;
            await childService.SetChildToGroupAsync(child, group);
            await unitOfWork.SaveChangesAsync();
        }

        private async Task<List<Group>> FindVaccantGroupsAsync(Child child)
        {
            List<GroupInDb> groupsFromDb = await unitOfWork.GroupRepository
                    .FindVacantGroupsAsync(
                        child.PreferableDays,
                        child.GameLevel,
                        maxChildren,
                        new ChildAgeRuleChecker().CreateRuleCheckerDelegate(child));
                
            List<Group> groups = groupsFromDb
                .Select(new GroupInDbToGroupMapper().Map)
                .ToList();
            return groups;
        }

        private Group CreateGroup(GameLevel gameLevel, DayOfWeek dayOfWeek)
        {
            Group group = new Group(gameLevel, dayOfWeek);
            return group;
        }

        private async Task ChooseDayAsync(Child child, Group group)
        {
            var rand = new Random();
            var index = rand.Next(child.PreferableDays.Count);
            child.LessonsDay = child.PreferableDays[index];
            group.LessonsDay = child.LessonsDay;
            
            await unitOfWork.GroupRepository.CreateAsync(
                new GroupToGroupInDbMapper().Map(group));
        }
    }
}