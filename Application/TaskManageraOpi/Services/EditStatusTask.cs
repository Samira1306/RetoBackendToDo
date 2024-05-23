using Application.Interface;
using Domain.Enums;
using Domain.Models;



namespace Application.TaskManageraOpi.Services
{
    public class EditStatusTask : IEditTask
    {
        private readonly IRepository _repository;

        public EditStatusTask(IRepository repository)
        {
            _repository = repository;
        }

        public async Task EditTaskStatus(string taskId, Status StatusTask)
        {
            TaskManagerModel taskSave = await _repository.GetTaskOne(taskId);
            if (taskSave != null)
            {
                taskSave.StatusTask = StatusTask;
                await _repository.UpdateChangesTask(taskSave);
            }
        }
    }
}
