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

            if (filters.Date != null)
            {
                taskItems = taskItems.Where(x => x.Date.ToShortDateString() == filters.Date.Value.ToShortDateString());
            }

            if (filters.Description != null)
            {
                taskItems = taskItems.Where(x => x.Description.ToLower().Contains(filters.Description.ToLower()));
            }

            var pagedLst = PagedList<TaskItem>.Create(taskItems, filters.PageNumber, filters.PageSize);
            return pagedLst;
        }

        public async Task InsertTaskItem(TaskItem taskItem)
        {
            //var user = await _unitOfWork.EmployeeRepository.GetById(taskItem.EmployeeID);
            //if (user == null)
            //{
            //    throw new BusinessException("User doesn't exist"); // Buisnes exception (example)
            //}

            await _unitOfWork.TaskItemRepository.Add(taskItem);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateTaskItem(TaskItem taskItem)
        {
            var objTaskItem = await _unitOfWork.TaskItemRepository.GetById(taskItem.Id);

            objTaskItem.Description = taskItem.Description;

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
