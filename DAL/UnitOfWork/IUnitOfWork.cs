using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Project> ProjectRepository { get; }
        IRepository<ProjectTask> ProjectTaskRepository { get; }
        IRepository<ProjectUser> UserRepository { get; }
        IRepository<DateInfo> DateInfoRepository { get;}
        IRepository<ProjectTaskStatus> ProjectTaskStatusRepository { get;}
        IRepository<UserContacts> UserContactsRepository { get;}

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
