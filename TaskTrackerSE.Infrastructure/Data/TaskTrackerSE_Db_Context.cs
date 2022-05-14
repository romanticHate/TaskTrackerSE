using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.Entities;
using TaskTrackerSE.Infrastructure.Data.Configuration;

namespace TaskTrackerSE.Infrastructure.Data
{
    public class TaskTrackerSE_Db_Context:DbContext
    {
        public TaskTrackerSE_Db_Context(){ }
        public TaskTrackerSE_Db_Context(DbContextOptions<TaskTrackerSE_Db_Context> option):base(option) { }

        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Security> Securities { get; set; }
        //public DbSet<Employee> Employees { get; set; }
        //public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new TaskItemConfiguration());
            modelBuilder.ApplyConfiguration(new SecurityConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
