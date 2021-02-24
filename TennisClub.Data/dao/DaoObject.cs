using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.model;

namespace TennisClub.Data.dao
{
    public class DaoObject
    {
        public IDao<IChild> ChildDao { get; } = (IDao<IChild>) new Dao<Child>();
        public IDao<IGroup> GroupDao { get; } = (IDao<IGroup>) new Dao<Group>();
        public ICachedGroupDao<ICachedGroup> CachedGroupDao { get; } = 
            (ICachedGroupDao<ICachedGroup>) new CachedGroupDao<CachedGroup>();
    }
}
