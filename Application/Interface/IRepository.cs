using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IRepository
    {
        Task<List<TaskManagerModel>> GetTaskMa();
        Task<TaskManagerModel> GetTaskOne(string id);
        Task<TaskManagerModel> GetNewTask(TaskManagerModel taskManager);
        Task UpdateChangesTask(TaskManagerModel taskManager);
    }
}
