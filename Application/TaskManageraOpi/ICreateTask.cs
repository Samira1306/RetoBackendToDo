using Domain.Enums;
using Domain.Models;
using System.Reflection;


namespace Application.TaskManageraOpi
{
    public interface ICreateTask
    {
        Task<TaskManagerModel> CreateTaskNew(string Title, Status StatusTask, string Detail, Priority Priority, DateTime ExpirationDate);
    }
}
