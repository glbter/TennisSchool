using System;
using TennisClub.Data.Context;
using TennisClub.Data.Repository.interfaces;

namespace TennisClub.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private IChildRepository childRepository;
        private IGroupRepository groupRepository;
        private IChildChosenDaysRepository childChosenDaysRepository;
        private readonly TennisClubContext _dbContext;
        private bool _disposed;
        
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

        public UnitOfWork(
            TennisClubContext context, 
            IChildRepository childRepository, 
            IGroupRepository groupRepository,
            IChildChosenDaysRepository childChosenDaysRepository)
        {
            _dbContext = context;
            ChildRepository = childRepository;
            GroupRepository = groupRepository;
            ChildChosenDaysRepository = childChosenDaysRepository;
            _disposed = false;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            
            if (disposing)
            {
                ChildRepository = null;
                GroupRepository = null;
                ChildChosenDaysRepository = null;
            }
            _dbContext.Dispose();
            _disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
