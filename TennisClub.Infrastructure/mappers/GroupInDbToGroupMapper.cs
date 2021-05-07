using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Model;

namespace TennisClub.Infrastructure.Mappers
{
    public class GroupInDbToGroupMapper : IMapper<GroupInDb, Group>
    {
        public Group Map(GroupInDb entity)
        {
            var group = new Group(
                id: entity.Id,
                gameLevel: entity.GameLevel,
                lessonsDay: entity.LessonsDay);
            group.ChildrenAmount = entity.ChildrenAmount;
            return group;
        }
    }
}