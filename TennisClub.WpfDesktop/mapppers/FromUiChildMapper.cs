using TennisClub.AppCore.model.impl;
using TennisClub.WpfDesktop.model;

namespace TennisClub.WpfDesktop.mapppers
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
                PreferableDay = entity.LessonsDay,
                Birthday = entity.Birthday
            };

        }
    }
}