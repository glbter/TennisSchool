using TennisClub.AppCore.model.impl;
using TennisClub.Infrastructure.mappers;
using TennisClub.WpfDesktop.model;

namespace TennisClub.WpfDesktop.mapppers
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