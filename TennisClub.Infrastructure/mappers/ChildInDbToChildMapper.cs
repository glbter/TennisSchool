using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Model;

namespace TennisClub.Infrastructure.Mappers
{
    public class ChildInDbToChildMapper : IMapper<ChildInDb, Child>
    {
        public Child Map(ChildInDb entity)
        {
            return new Child(
                firstName: entity.FirstName,
                lastName: entity.LastName,
                gameLevel: entity.GameLevel,
                lessonsDay: entity.PreferableDay,
                birthday: entity.Birthday,
                id: entity.Id);
        }
    }
}