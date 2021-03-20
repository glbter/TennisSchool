using System.Collections.Generic;
using TennisClub.AppCore.model.impl;
using TennisClub.Data.model;

namespace TennisClub.Infrastructure.mappers
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
                preferableDay: entity.PreferableDay,
                birthday: entity.Birthday);
        }
    }
}