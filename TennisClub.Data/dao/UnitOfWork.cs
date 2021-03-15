using System;
using Microsoft.EntityFrameworkCore;
using TennisClub.AppCore.model.impl;
using TennisClub.AppCore.model.interfaces;
using TennisClub.Data.dao.interfaces;
using TennisClub.Data.model;
using TennisClub.Data.context;

namespace TennisClub.Data.dao
{
    public class UnitOfWork : IUnitOfWork
    {
        public IChildRepository ChildRepository { get; }
        public IGroupRepository GroupRepository { get; }
        private readonly PostgresDbContext _dbContext;

        public UnitOfWork()
        {
            // var options = new DbContextOptionsBuilder<InMemoryDbContext>()
            //     .UseInMemoryDatabase(databaseName: "InMemory")
            //     .Options;
            var options = new DbContextOptionsBuilder<PostgresDbContext>().UseNpgsql().Options;
            _dbContext = new PostgresDbContext(options);
            
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
