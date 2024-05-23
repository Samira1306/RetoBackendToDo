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
    public class GetAllTasks : IGetAllTasks
    {
        private readonly IRepository _repository;

        public GetAllTasks(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskManagerModel>> GetTasks()
        {
            List<TaskManagerModel> TaskPriority = await _repository.GetTaskMa();
            return (TaskPriority.OrderByDescending(filter => filter.Priority == Priority.High).ThenBy(filter => filter.Priority == Priority.Low)).ToList();
        }
    }
}
