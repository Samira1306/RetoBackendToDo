using Domain.Models;


namespace Application.TaskManageraOpi
{
    public interface IGetTaskById
    {
        Task<TaskManagerModel> GetTask(string id);
    }
}
