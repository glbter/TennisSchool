using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.interfaces;

namespace TennisClub.Infrastructure.services
{
    public class ChildService<TK> : IChildService<TK>
    {
        private readonly UnitOfWork dao;
        public ChildService(UnitOfWork dao)
        {
            this.dao = dao;
        }

        public void SetChildToGroup(IChild<TK> child, ICachedGroup<TK> group)
        {
            child.GroupId = group.Id;
            dao.ChildDao.Create((Child)child);
            group.ChildrenAmount += 1;
        }
    }
}
