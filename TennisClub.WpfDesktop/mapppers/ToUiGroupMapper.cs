using TennisClub.AppCore.model.impl;
using TennisClub.WpfDesktop.model;

namespace TennisClub.WpfDesktop.mapppers
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