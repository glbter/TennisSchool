using TennisClub.AppCore.model.impl;
using TennisClub.WpfDesktop.model;

namespace TennisClub.WpfDesktop.mapppers
{
    public class ToUiChildMapper : IMapper<Child, ChildWpf>
    {
        public ChildWpf Map(Child entity)
        {
            return new ChildWpf(
                entity.Id,
                entity.FirstName,
                entity.LastName,
                entity.GameLevel,
                entity.PreferableDay,
                entity.Age);
        }
    }
}