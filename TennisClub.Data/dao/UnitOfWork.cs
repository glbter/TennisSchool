using Microsoft.EntityFrameworkCore;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.context;

namespace TennisClub.Data.dao
{
    public class UnitOfWork : IUnitOfWork
    {
        public IChildRepository ChildRepository { get; }
        public IGroupRepository GroupRepository { get; }
        public IChildChosenDaysRepository ChildChosenDaysRepository { get; }
        private readonly PostgresDbContext _dbContext;

        public UnitOfWork(string connectionString)
        {
            var options = new DbContextOptionsBuilder<PostgresDbContext>().UseNpgsql().Options;
            _dbContext = new PostgresDbContext(connectionString, options);
            
            ChildRepository = new ChildRepository(_dbContext);//inject
            GroupRepository = new GroupRepository(_dbContext);
            ChildChosenDaysRepository = new ChildChosenDaysRepository(_dbContext);
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
