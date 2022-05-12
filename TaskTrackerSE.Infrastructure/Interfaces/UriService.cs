using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.QueryFilters;

namespace TaskTrackerSE.Infrastructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPostPaginationUri(TaskItemQueryFilter filter, string actionUrl);
    }
}
