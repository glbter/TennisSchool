using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Model;

namespace TennisClub.Infrastructure.Mappers
{
    public class GroupInDbNullableToGroupMapper : IMapper<GroupInDb, Group>
    {
        public Group Map(GroupInDb entity)
        {
            if (entity != null)
            {
                var group = new Group(
                    id: entity.Id,
                    gameLevel: entity.GameLevel,
                    lessonsDay: entity.LessonsDay);
                group.ChildrenAmount = entity.ChildrenAmount;
                return group;
            }
            else return null;   
        }
    }
}