using DAL.Base;
using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public UnitOfWork(TaskTrackerContext context) =>
            _context = context;

        readonly TaskTrackerContext _context;

        IRepository<Project> projectRepository;
        IRepository<ProjectTask> projectTaskRepository;
        IRepository<User> userRepository;
        IRepository<DateInfo> dateInfoRepository;
        IRepository<ProjectTaskStatus> projectTaskStatusRepository;
        IRepository<UserContacts> userContactsRepository;

        public IRepository<Project> ProjectRepository => 
            projectRepository ?? new Repository<Project>(_context);

        public IRepository<ProjectTask> ProjectTaskRepository =>
            projectTaskRepository ?? new Repository<ProjectTask>(_context);

        public IRepository<User> UserRepository =>
            userRepository ?? new Repository<User>(_context);

        public IRepository<DateInfo> DateInfoRepository =>
            dateInfoRepository ?? new Repository<DateInfo>(_context);

        public IRepository<ProjectTaskStatus> ProjectTaskStatusRepository =>
            projectTaskStatusRepository ?? new Repository<ProjectTaskStatus>(_context);

        public IRepository<UserContacts> UserContactsRepository =>
            userContactsRepository ?? new Repository<UserContacts>(_context);

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
             await _context.SaveChangesAsync();
        }

        bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
