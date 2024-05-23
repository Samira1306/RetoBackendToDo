using Domain.Models;


namespace Application.TaskManageraOpi
{
    public interface IGetAllTasks
    {
        Task<List<TaskManagerModel>> GetTasks();
    }
}
