using TennisClub.AppCore.model.impl;
using TennisClub.Infrastructure.mappers;
using TennisClub.WpfDesktop.model;

namespace TennisClub.WpfDesktop.mapppers
{
    public class FromUiChildMapper : IMapper<ChildWpf, Child>
    {
        public Child Map(ChildWpf entity)
        {
            var child = new Child()
            {
                FirstName = entity.Name,
                LastName = entity.LastName,
                GameLevel = entity.GameLevel,
                Id = entity.Id,
                LessonsDay = entity.LessonsDay,
                Birthday = entity.Birthday
            };
            child.PreferableDays = entity.PreferableDays;
            return child;
        }
    }
}