using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerSE.Core.QueryFilters
{
    public class TaskItemQueryFilter
    {
        public string? Title { get; set; }
        public DateTime? Date { get; set; }      
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
