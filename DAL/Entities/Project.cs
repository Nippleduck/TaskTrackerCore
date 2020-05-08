using DAL.Entities.Abstract;
using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Project : BaseEntity<int>
    {
        public Project()
        {
            Tasks = new HashSet<ProjectTask>();
            Users = new HashSet<User>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }
        public int UserId { get; set; }

        public virtual User Manager { get; set; }

        public virtual ICollection<ProjectTask> Tasks { get; set; }
        public virtual ICollection<User> Users { get; set; }
        
    }
}
