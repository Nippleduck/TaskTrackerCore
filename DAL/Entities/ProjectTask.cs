using DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class ProjectTask : BaseEntity<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ProjectTaskStatus TaskStatus { get; set; }
        public virtual DateInfo DateInfo { get; set; }
        public virtual ProjectUser Performer { get; set; }
    }
}
