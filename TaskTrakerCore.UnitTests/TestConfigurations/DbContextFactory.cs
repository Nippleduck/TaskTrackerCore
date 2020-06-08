using System;
using System.Collections.Generic;
using System.Text;
using DAL.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Moq;

namespace TaskTrakerCore.UnitTests.TestConfigurations
{
    public static class DbContextFactory
    {
        public static TaskTrackerContext Create()
        {
            var options = new DbContextOptionsBuilder<TaskTrackerContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new TaskTrackerContext(options);

            TaskTrackerContextSeeder.Seed(context);

            return context;
        }

        public static void RemoveContext(TaskTrackerContext context)
        {
            context.Database.EnsureCreated();
            context.Dispose();
        }
    }
}
