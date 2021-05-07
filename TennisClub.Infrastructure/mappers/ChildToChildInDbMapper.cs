using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Model;

namespace TennisClub.Infrastructure.Mappers
{
    public class ChildToChildInDbMapper : IMapper<Child, ChildInDb>
    {
        public ChildInDb Map(Child entity)
        {
            return new ChildInDb(
                id: entity.Id,
                groupId: entity.GroupId,
                firstName: entity.FirstName,
                lastName: entity.LastName,
                gameLevel: entity.GameLevel,
                preferableDay: entity.LessonsDay,
                birthday: entity.Birthday);
        }
    }
}