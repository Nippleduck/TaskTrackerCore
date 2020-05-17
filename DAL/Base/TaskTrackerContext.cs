﻿using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DAL.Entities.IdentityModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL.Base
{
    internal class TaskTrackerContext : IdentityDbContext<ApplicationUser>
    {
        public TaskTrackerContext(DbContextOptions<TaskTrackerContext> options)
            : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<ProjectUser> ProjectUsers { get; set; }
        public DbSet<DateInfo> DateInfos { get; set; }
        public DbSet<ProjectTaskStatus> TaskStatuses { get; set; }
        public DbSet<UserContacts> UserContacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
