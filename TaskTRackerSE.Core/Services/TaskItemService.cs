using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTrackerSE.Core.CustomEntities;
using TaskTrackerSE.Core.Entities;
using TaskTrackerSE.Core.Exceptions;
using TaskTrackerSE.Core.Interfaces;
using TaskTrackerSE.Core.QueryFilters;

namespace TaskTrackerSE.Core.Services
{
    public class TaskItemService : ITaskItemService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly PaginationOptions _paginationOptions;
        public TaskItemService(IUnitOfWork unitOfWork, IOptions<PaginationOptions> options)
        {
            _unitOfWork = unitOfWork;
            _paginationOptions = options.Value;
        }

        public async Task<TaskItem> GetTaskItem(int id)
        {
            return await _unitOfWork.TaskItemRepository.GetById(id);
        }

        public PagedList<TaskItem> GetTaskItems(TaskItemQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? _paginationOptions.DefaultPageNumber : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? _paginationOptions.DefaultPageSize : filters.PageSize;

            var taskItems = _unitOfWork.TaskItemRepository.GetAll();

            if (filters.Title != null)
            {
                taskItems = taskItems.Where(x => x.Title.ToLower().Contains(filters.Title.ToLower()));
            }

            if (filters.Date != null)
            {
                taskItems = taskItems.Where(x => x.Date.ToShortDateString() == filters.Date.Value.ToShortDateString());
            }

            var pagedLst = PagedList<TaskItem>.Create(taskItems, filters.PageNumber, filters.PageSize);
            return pagedLst;
        }

        public async Task InsertTaskItem(TaskItem taskItem)
        {
            await _unitOfWork.TaskItemRepository.Add(taskItem);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateTaskItem(TaskItem taskItem)
        {
            var objTaskItem = await _unitOfWork.TaskItemRepository.GetById(taskItem.Id);
            objTaskItem.Title = taskItem.Title;
            objTaskItem.Description = taskItem.Description;
            objTaskItem.Date = taskItem.Date;
            objTaskItem.IsActive = taskItem.IsActive;

            _unitOfWork.TaskItemRepository.Update(objTaskItem);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }      

        public async Task<bool> DeletTaskItem(int id)
        {
            await _unitOfWork.TaskItemRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
