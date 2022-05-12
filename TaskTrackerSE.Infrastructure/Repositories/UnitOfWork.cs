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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskTrackerSE_Db_Context _context;

        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly ITaskItemRepository _taskItemRepository;      
        private readonly ISecurityRepository _securityRepository;

        public UnitOfWork(TaskTrackerSE_Db_Context context)
        {
            _context = context;
        }

        // Generic repositories
        public IRepository<Person> PersonRepository => _personRepository ?? new BaseRepository<Person>(_context);
        public IRepository<Employee> EmployeeRepository => _employeeRepository ?? new BaseRepository<Employee>(_context);

        // Normal Repositories
        public ITaskItemRepository TaskItemRepository => _taskItemRepository ?? new TaskItemRepository(_context);     
        public ISecurityRepository SecurityRepository => _securityRepository ?? new SecurityRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
