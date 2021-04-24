using TennisClub.AppCore.model.impl;
using TennisClub.Infrastructure.mappers;
using TennisClub.WpfDesktop.model;

namespace TennisClub.WpfDesktop.mapppers
{
    public class ToUiChildMapper : IMapper<Child, ChildWpf>
    {
        public ChildWpf Map(Child entity)
        {
            var child = new ChildWpf(
                entity.FirstName,
                entity.LastName,
                entity.GameLevel,
                entity.LessonsDay,
                entity.Birthday,
                entity.Id);
            child.PreferableDays = entity.PreferableDays;
            return child;
        }
    }
}