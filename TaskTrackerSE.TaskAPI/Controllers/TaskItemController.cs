using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using TaskTrackerSE.Core.CustomEntities;
using TaskTrackerSE.Core.DTOs;
using TaskTrackerSE.Core.Entities;
using TaskTrackerSE.Core.Interfaces;
using TaskTrackerSE.Core.QueryFilters;
using TaskTrackerSE.Infrastructure.Interfaces;
using TaskTrackerSE.TaskAPI.Response;

namespace TaskTrackerSE.TaskAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TaskitemController : ControllerBase
    {
        private readonly ITaskItemService _taskItemService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;

        public TaskitemController(ITaskItemService postService, IMapper mapper, IUriService uriService)
        {
            _taskItemService = postService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Retrieve all taskItems
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetTaskItems))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<TaskItemDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetTaskItems([FromQuery] TaskItemQueryFilter filters)
        {
            var taskItems = _taskItemService.GetTaskItems(filters);
            var taskItemsDtos = _mapper.Map<IEnumerable<TaskItemDto>>(taskItems);

            var metadata = new Metadata
            {
                TotalCount = taskItems.TotalCount,
                PageSize = taskItems.PageSize,
                CurrentPage = taskItems.CurrentPage,
                TotalPages = taskItems.TotalPages,
                HasNextPage = taskItems.HasNextPage,
                HasPreviousPage = taskItems.HasPreviousPage,
                NextPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetTaskItems))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetTaskItems))).ToString()
            };

            var response = new ApiResponse<IEnumerable<TaskItemDto>>(taskItemsDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskItem(int id)
        {
            var taskItem = await _taskItemService.GetTaskItem(id);
            var postDto = _mapper.Map<TaskItemDto>(taskItem);
            var response = new ApiResponse<TaskItemDto>(postDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> PostTaskItem(TaskItemDto taskItemDto)
        {
            var taskItem = _mapper.Map<TaskItem>(taskItemDto);

            await _taskItemService.InsertTaskItem(taskItem);

            taskItemDto = _mapper.Map<TaskItemDto>(taskItem);
            var response = new ApiResponse<TaskItemDto>(taskItemDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> PutTaskItem(int id, TaskItemDto taskItemDto)
        {
            var taskItem = _mapper.Map<TaskItem>(taskItemDto);
            taskItem.Id = id;

            var result = await _taskItemService.UpdateTaskItem(taskItem);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            var result = await _taskItemService.DeletTaskItem(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
