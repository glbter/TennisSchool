using TennisClub.AppCore.model.impl;
using TennisClub.Data.model;

namespace TennisClub.Infrastructure.mappers
{
    public class ChildInDbToChildMapper : IMapper<ChildInDb, Child>
    {
        public Child Map(ChildInDb entity)
        {
            return new Child(
                firstName: entity.FirstName,
                lastName: entity.LastName,
                gameLevel: entity.GameLevel,
                lessonsDay: entity.LessonsDay,
                birthday: entity.Birthday,
                id: entity.Id);
        }
    }
}