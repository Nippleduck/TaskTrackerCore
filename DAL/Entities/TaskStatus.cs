using DAL.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class TaskStatus : BaseEntity<int>
    {
        public decimal ExecutedPercent { get; set; }
        public int State { get; set; }
    }
}
