using TennisClub.AppCore.model.impl;
using TennisClub.Data.model;

namespace TennisClub.Infrastructure.mappers
{
    public class GroupToGroupInDbMapper : IMapper<Group, GroupInDb>
    {
        public GroupInDb Map(Group entity)
        {
            return new GroupInDb(
                id: entity.Id,
                gameLevel: entity.GameLevel,
                lessonsDay: entity.LessonsDay);
        }
    }
}