using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TaskTrackerSE.Core.DTOs;
using TaskTrackerSE.Core.Entities;

namespace TaskTrackerSE.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<TaskItem, TaskItemDto>();
            CreateMap<TaskItemDto, TaskItem>();

            CreateMap<Security, SecurityDto>().ReverseMap();
        }
    }
}
