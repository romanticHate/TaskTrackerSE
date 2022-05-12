using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.CustomEntities;
using TaskTrackerSE.Core.Entities;
using TaskTrackerSE.Core.QueryFilters;

namespace TaskTrackerSE.Core.Interfaces
{
    public interface ITaskItemService
    {
        PagedList<TaskItem> GetTaskItems(TaskItemQueryFilter filters);

        Task<TaskItem> GetTaskItem(int id);

        Task InsertTaskItem(TaskItem post);

        Task<bool> UpdateTaskItem(TaskItem post);

        Task<bool> DeletTaskItem(int id);
    }
}
