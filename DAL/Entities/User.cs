using DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class User : BaseEntity<int>
    {
        public User() => Tasks = new HashSet<Task>();

        public string Name { get; set; }
        public string UserContactsId { get; set; }

        public UserContacts UserContacts { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
