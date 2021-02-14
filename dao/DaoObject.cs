using Lab1.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.dao
{
    public class DaoObject
    {
        public IDao<Child> ChildDao { get; } = new Dao<Child>();
        public IDao<Group> GroupDao { get; } = new Dao<Group>();
        public ICachedGroupDao CachedGroupDao { get; } = new CachedGroupDao();
    }
}
