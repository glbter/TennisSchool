using TennisClub.AppCore.model.impl;
using TennisClub.WpfUi.model;

namespace TennisClub.WpfUi.mappers
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