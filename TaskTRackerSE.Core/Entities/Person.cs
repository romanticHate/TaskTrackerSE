using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.Interfaces;

namespace TaskTrackerSE.Core.Entities
{
    public class Person : BaseEntity    
    {       
        public string Firstame { get; set; } 
        public string LastName { get; set; } 
        public DateTime DateOfbirth { get; set; }
        public int? Age { get; set; }

        /// <summary>  
        /// Calculate age  
        /// </summary>      
        /// <returns> age e.g. 26</returns>  
        public void CalculateAge()
        {
            var age = DateTime.Now.Year - DateOfbirth.Year;

            if (DateTime.Now.DayOfYear < DateOfbirth.DayOfYear)
                 age = age - 1;

            Age = age;
        }
    }
}
