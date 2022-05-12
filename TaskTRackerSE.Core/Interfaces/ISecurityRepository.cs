using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.Entities;

namespace TaskTrackerSE.Core.Interfaces
{
    public interface ISecurityRepository : IRepository<Security>
    {
        Task<Security> GetLoginByCredentials(UserLogin login);
    }
}
