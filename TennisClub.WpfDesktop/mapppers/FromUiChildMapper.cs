using TennisClub.AppCore.Model.impl;
using TennisClub.Infrastructure.Mappers;
using TennisClub.WpfDesktop.Model;

namespace TennisClub.WpfDesktop.Mapppers
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