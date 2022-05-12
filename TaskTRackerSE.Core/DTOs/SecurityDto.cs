﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.Enumerations;

namespace TaskTrackerSE.Core.DTOs
{
    public class SecurityDto
    {
        public string User { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public RoleType? Role { get; set; }
    }
}
