using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Model;

namespace TennisClub.Infrastructure.Mappers
{
    public class GroupToGroupInDbMapper : IMapper<Group, GroupInDb>
    {
        public GroupInDb Map(Group entity)
        {
            var group = new GroupInDb(
                id: entity.Id,
                gameLevel: entity.GameLevel,
                lessonsDay: entity.LessonsDay);
            group.ChildrenAmount = entity.ChildrenAmount;
            return group;
        }
    }
}