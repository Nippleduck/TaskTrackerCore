﻿using DAL.Entities.Abstract;
using DAL.Entities.Enums;
using DAL.Entities.IdentityModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ProjectUser : BaseEntity<int>
    {
        public ProjectUser() => Tasks = new HashSet<ProjectTask>();

        public string Name { get; set; }
        public string UserContactsId { get; set; }
        public UserRole Role { get; set; }
        public int ProjectId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual UserContacts UserContacts { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<ProjectTask> Tasks { get; set; }
    }
}