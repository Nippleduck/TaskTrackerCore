using DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Project : BaseEntity<int>
    {
        public Project()
        {
            Tasks = new HashSet<Task>();
            Users = new HashSet<User>();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int UserId { get; set; }

        public virtual User Manager { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
        public virtual ICollection<User> Users { get; set; }
        
    }
}
