using TennisClub.AppCore.model.impl;
using TennisClub.WpfUi.model;

namespace TennisClub.WpfUi.mappers
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