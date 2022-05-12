using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerSE.Core.Entities
{
    public class TaskItem:BaseEntity
    {       
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }

        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
    }
}
