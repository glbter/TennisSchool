﻿using TennisClub.AppCore.model.impl;
using TennisClub.Data.mappers;
using TennisClub.Data.model;

namespace TennisClub.Infrastructure.mappers
{
    public class GroupInDbToGroupMapper : IMapper<GroupInDb, Group>
    {
        public Group Map(GroupInDb entity)
        {
            return new Group(
                id: entity.Id,
                gameLevel: entity.GameLevel,
                lessonsDay: entity.LessonsDay);
        }
    }
}