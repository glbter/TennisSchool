using TennisClub.Data.dao.interfaces;
using TennisClub.Data.context;

namespace TennisClub.Data.dao
{
    public class UnitOfWork : IUnitOfWork
    {
        private IChildRepository childRepository;
        private IGroupRepository groupRepository;
        private IChildChosenDaysRepository childChosenDaysRepository;
        private readonly TennisClubContext _dbContext;
        
        public IChildRepository ChildRepository
        {
            get => childRepository ??= new ChildRepository(_dbContext);
            set => childRepository ??= value;
        }

        public IGroupRepository GroupRepository
        {
            get => groupRepository ??= new GroupRepository(_dbContext);
            set => groupRepository ??= value;
        }

        public IChildChosenDaysRepository ChildChosenDaysRepository
        {
            get => childChosenDaysRepository ??= 
                new ChildChosenDaysRepository(_dbContext);
            set => childChosenDaysRepository ??= value;
        }

        public UnitOfWork(TennisClubContext context)
        {
            _dbContext = context;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
