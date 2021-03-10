using System;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.model;

namespace TennisClub.Data.dao
{
    public class UnitOfWork
    {
        public IDao<Child, Guid> ChildDao { get; } = new Dao<Child, Guid>();
        public IDao<Group, Guid> GroupDao { get; } = new Dao<Group, Guid>();
        public ICachedGroupDao<CachedGroup, Guid> CachedGroupDao { get; } = new CachedGroupDao<CachedGroup, Guid>();
    }
}
