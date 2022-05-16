using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerSE.Core.QueryFilters
{
    public class EmployeeQueryFilter
    {   
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
