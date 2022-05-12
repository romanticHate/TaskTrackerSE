using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.Entities;

namespace TaskTrackerSE.Core.Interfaces
{
    public interface ISecurityService
    {
        Task<Security> GetLoginByCredentials(UserLogin userLogin);
        Task RegisterUser(Security security);
    }
}
