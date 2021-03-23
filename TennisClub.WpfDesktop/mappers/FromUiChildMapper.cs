using TennisClub.AppCore.model.impl;
using TennisClub.WpfDesktop.model;

namespace TennisClub.WpfDesktop.mappers
{
    public class FromUiChildMapper : IMapper<ChildWpf, Child>
    {
        public Child Map(ChildWpf entity)
        {
            return new Child()
            {
                FirstName = entity.Name,
                LastName = entity.LastName,
                GameLevel = entity.GameLevel,
                Id = entity.Id,
                PreferableDay = entity.LessonsDay
            };

        }
    }
}