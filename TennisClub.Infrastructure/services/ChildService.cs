using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.dao;


namespace TennisClub.Infrastructure.services
{
    public class ChildService
    {
        private readonly DaoObject dao;
        public ChildService(DaoObject dao)
        {
            this.dao = dao;
        }

        public void SetChildToGroup(IChild child, ICachedGroup group)
        {
            child.GroupId = group.Id;
            dao.ChildDao.Create((Child)child);
            group.ChildrenAmount += 1;
        }
    }
}
