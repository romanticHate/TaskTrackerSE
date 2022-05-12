using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.Entities;
using TaskTrackerSE.Core.Interfaces;
using TaskTrackerSE.Infrastructure.Data;

namespace TaskTrackerSE.Infrastructure.Repositories
{
    public class TaskItemRepository : BaseRepository<TaskItem>, ITaskItemRepository
    {
        public TaskItemRepository(TaskTrackerSE_Db_Context context) : base(context) { }

        public async Task<IEnumerable<TaskItem>> GetAllTaskItemByEmployee(int employeeId)
        {
            return await _entities.Where(t => t.EmployeeID == employeeId).ToListAsync();
        }
    }
}
