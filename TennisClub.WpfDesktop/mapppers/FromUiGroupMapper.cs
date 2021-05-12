using TennisClub.AppCore.Model.impl;
using TennisClub.Infrastructure.Mappers;
using TennisClub.WpfDesktop.Model;

namespace TennisClub.WpfDesktop.Mapppers
{
    public class FromUiGroupMapper : IMapper<GroupWpf, Group>
    {
        public Group Map(GroupWpf entity)
        {
            return new Group(
                gameLevel: entity.GameLevel,
                lessonsDay: entity.LessonsDay,
                id: entity.Id);
        }
    }
}