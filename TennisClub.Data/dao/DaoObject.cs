using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.model;

namespace TennisClub.Data.dao
{
    public class DaoObject
    {
        public IDao<Child> ChildDao { get; } = new Dao<Child>();
        public IDao<Group> GroupDao { get; } = new Dao<Group>();
        public ICachedGroupDao<CachedGroup> CachedGroupDao { get; } = new CachedGroupDao<CachedGroup>();
    }
}
