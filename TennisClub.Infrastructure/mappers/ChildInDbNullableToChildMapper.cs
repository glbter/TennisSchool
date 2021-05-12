using TennisClub.AppCore.Model.impl;
using TennisClub.Data.Model;

namespace TennisClub.Infrastructure.Mappers
{
    public class ChildInDbNullableToChildMapper : IMapper<ChildInDb, Child>
    {
        public Child Map(ChildInDb entity)
        {
            if (entity != null)
                return new Child(
                    firstName: entity.FirstName,
                    lastName: entity.LastName,
                    gameLevel: entity.GameLevel,
                    lessonsDay: entity.PreferableDay,
                    birthday: entity.Birthday,
                    id: entity.Id);
            else return null;
        }
    }
}