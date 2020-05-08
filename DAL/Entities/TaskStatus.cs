using DAL.Entities.Abstract;
using DAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class TaskStatus : BaseEntity<int>
    {
        public decimal ExecutedPercent { get; set; }
        public TaskState State { get; set; }
    }
}
