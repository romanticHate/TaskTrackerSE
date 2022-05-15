using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerSE.Core.DTOs
{
    public class TaskItemDto
    {
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public bool IsActive { get; set; }
        public string? Description { get; set; }

    }
}
