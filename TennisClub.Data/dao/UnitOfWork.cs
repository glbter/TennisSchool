using System.Data.Common;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.context;

namespace TennisClub.Data.dao
{
    public class UnitOfWork : IUnitOfWork
    {
        public IChildRepository ChildRepository { get; }
        public IGroupRepository GroupRepository { get; }
        private readonly PostgresDbContext _dbContext;

        public UnitOfWork(string connectionString, ProviderDb provider)
        {
            
            var conn = DbProviderFactories.GetFactory(provider.ToString()).CreateConnection(); 
            conn.ConnectionString = connectionString;
            _dbContext = new PostgresDbContext(conn);
            
            //_dbContext = new InMemoryDbContext(options);
            ChildRepository = new ChildRepository(_dbContext);
            GroupRepository = new GroupRepository(_dbContext);
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
