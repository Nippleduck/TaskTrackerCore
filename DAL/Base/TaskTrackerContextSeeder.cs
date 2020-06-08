using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Base
{
    public static class TaskTrackerContextSeeder
    {
        public static void Seed(TaskTrackerContext context)
        {
            var projectsList = new List<Project>
            {
                new Project
                {
                    Title = "Web application",
                    Description = "create new web app",
                    Status = Entities.Enums.ProjectStatus.Open,
                    ProjectManager = new ProjectUser{Name = "Anna"}
                },
                new Project
                {
                    Title = "MVC application",
                    Description = "create new MVC app",
                    Status = Entities.Enums.ProjectStatus.Open,
                    ProjectManager = new ProjectUser{Name = "James"}
                },
                new Project
                {
                    Title = "API project",
                    Description = "create new API project",
                    Status = Entities.Enums.ProjectStatus.Open,
                    ProjectManager = new ProjectUser{Name = "Liam"}
                },
                new Project
                {
                    Title = "Angular app",
                    Description = "create new Angular app",
                    Status = Entities.Enums.ProjectStatus.Open,
                    ProjectManager = new ProjectUser{Name = "Jessica"}
                }
            };

            foreach (var proj in projectsList)
                context.Projects.Add(proj);

            context.SaveChanges();
        }
    }
}
