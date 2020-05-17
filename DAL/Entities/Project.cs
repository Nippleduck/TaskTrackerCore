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
            Users = new HashSet<ProjectUser>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public ProjectStatus Status { get; set; }

        public virtual ProjectUser ProjectManager { get; set; }

        public virtual ICollection<ProjectTask> Tasks { get; set; }
        public virtual ICollection<ProjectUser> Users { get; set; }
        
    }
}
