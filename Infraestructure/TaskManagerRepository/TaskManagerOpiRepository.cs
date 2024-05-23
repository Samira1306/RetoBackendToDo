using Application.Interface;
using Domain.Models;
using Infrastructure.TaskManagerDbContext;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.TaskManagerRepository
{
    public class TaskManagerOpiRepository: IRepository
    {
        private readonly TaskDbContext _context;

        public TaskManagerOpiRepository(TaskDbContext context) { 
            _context = context; 
        }

        public async Task<TaskManagerModel> GetNewTask(TaskManagerModel taskManager)
        {
           _context.Add(taskManager);
            await _context.SaveChangesAsync();
            return taskManager;
        }

        public async Task<List<TaskManagerModel>> GetTaskMa()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskManagerModel> GetTaskOne(string id)
        {
            return  _context.Tasks.ToList().FirstOrDefault(entity => entity.Id == id);
        }
        public async Task UpdateChangesTask(TaskManagerModel taskManager)
        {
            _context.Update(taskManager);
            await _context.SaveChangesAsync();
        }
    }
}
