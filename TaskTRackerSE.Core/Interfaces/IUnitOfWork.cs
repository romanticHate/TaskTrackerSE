using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.Entities;

namespace TaskTrackerSE.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ITaskItemRepository TaskItemRepository { get; }
        ISecurityRepository SecurityRepository { get; }

        IRepository<Person> PersonRepository { get; }
        IRepository<Employee> EmployeeRepository { get; }
     

        void SaveChanges();

        Task SaveChangesAsync();
    }
}
