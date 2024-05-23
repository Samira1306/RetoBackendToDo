using Application.Interface;
using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskManageraOpi.Services
{
    public class CreateTask : ICreateTask
    {
        private readonly IRepository _repository;

        public CreateTask(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskManagerModel> CreateTaskNew(TaskManagerModel task)
        {
            task.ExpirationDate = DateTime.Now.AddDays(1);
            task.Id = Guid.NewGuid().ToString();
            await _repository.GetNewTask(task);
            return task;
        }

        public async Task<TaskManagerModel> CreateTaskNew(string Title, Status StatusTask, string Detail, Priority Priority, DateTime ExpirationDate)
        {
            TaskManagerModel taskManagerModel = new TaskManagerModel()
            {
                Id = Guid.NewGuid().ToString(),
                IdUser = "1",
                Title = Title,
                StatusTask = StatusTask,
                Detail = Detail,
                ExpirationDate = ExpirationDate,
                Priority = Priority,
            }; 
            await _repository.GetNewTask(taskManagerModel);
            return taskManagerModel;
        }
    }
}
