using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.interfaces;

namespace TennisClub.Infrastructure.services
{
    public class ChildService<TK> : IChildService<TK>
    {
        private readonly DaoObject dao;
        public ChildService(DaoObject dao)
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
