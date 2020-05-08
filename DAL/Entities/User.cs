﻿using DAL.Entities.Abstract;
using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User : BaseEntity<int>
    {
        public User() => Tasks = new HashSet<ProjectTask>();

        public string Name { get; set; }
        public string UserContactsId { get; set; }
        public UserRole Role { get; set; }
        public int ProjectId { get; set; }

        public UserContacts UserContacts { get; set; }
        public Project Project { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
