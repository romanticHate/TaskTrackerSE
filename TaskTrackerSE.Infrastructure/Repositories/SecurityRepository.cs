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
    public class SecurityRepository : BaseRepository<Security>, ISecurityRepository
    {
        public SecurityRepository(TaskTrackerSE_Db_Context context) : base(context) { }

        public async Task<Security> GetLoginByCredentials(UserLogin login)
        {
            return await _entities.FirstOrDefaultAsync(x => x.User == login.User);
        }
    }
}
