using TennisClub.AppCore.Model.impl;
using TennisClub.Infrastructure.Mappers;
using TennisClub.WpfDesktop.Model;

namespace TennisClub.WpfDesktop.Mapppers
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