using TennisClub.AppCore.model.impl;
using TennisClub.WpfUi.model;

namespace TennisClub.WpfUi.mappers
{
    public class ToUiGroupMapper : IMapper<Group, GroupWpf>
    {
        public GroupWpf Map(Group entity)
        {
            return new GroupWpf(
                entity.GameLevel,
                entity.LessonsDay,
                entity.Id);
        }
    }
}