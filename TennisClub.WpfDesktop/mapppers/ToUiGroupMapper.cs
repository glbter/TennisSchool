using TennisClub.AppCore.Model.impl;
using TennisClub.Infrastructure.Mappers;
using TennisClub.WpfDesktop.Model;

namespace TennisClub.WpfDesktop.Mapppers
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