using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.Interfaces;

namespace TaskTrackerSE.Core.Entities
{
    public  class Employee: Person
    {       
        public string UserName { get; set; }
        public string Password  { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }

        /// <summary>  
        /// Assign Email 
        /// </summary>      
        /// <returns> email e.g. ant-valadés@evil.corp</returns>
        public virtual void AssignEmail() 
        {
            if (Firstame == null) 
            { 
                Console.WriteLine("Firstame is null"); 
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Email += Firstame[i];
                }                       
            }                       

            Email = Email.ToUpper() + ("-" + LastName + "@evil.corp");
        }

        public virtual ICollection<TaskItem> TaskItems { get; set;}
    }
}
