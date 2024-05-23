using Application.Email;
using Application.TaskManageraOpi;
using Domain.Enums;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace TaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagerController : ControllerBase
    {
        private readonly ICreateTask _createTask;
        private readonly IGetAllTasks _getAllTasks;
        private readonly IGetTaskById _getTaskById;
        private readonly IEditTask _editTask;
        private readonly ISendGrid _sendGrid;

        public TaskManagerController(ICreateTask createTask, IGetAllTasks getAllTasks, IGetTaskById getTaskById, IEditTask editTask, ISendGrid sendGrid)
        {
            _createTask = createTask;
            _getAllTasks = getAllTasks;
            _getTaskById = getTaskById;
            _editTask = editTask;
            _sendGrid = sendGrid;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var taskList = await _getAllTasks.GetTasks();
                return Ok(taskList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var taskOne = await _getTaskById.GetTask(id);
            return Ok(taskOne);
            
        }

        [HttpPost]
        public async Task<TaskManagerModel> Post(Model model)
        {

                return await _createTask.CreateTaskNew(model.Title,model.StatusTask,model.Detail,model.Priority,model.ExpirationDate);
        }

        [HttpPut]
        public async Task EditTaskStatus(UpdateModel updateModel)
        {
            await _editTask.EditTaskStatus(updateModel.Id,updateModel.StatusTask); 
        }

        [HttpPost]
        [Route("/sendEmail")]
        public async Task Email(SendGridModel sendGridModel)
        {
            await _sendGrid.Message(sendGridModel.receives,sendGridModel.body);
        }
    }

    public class UpdateModel
    {
        public string Id { get; set; }
        public Status StatusTask { get; set; }
    }

    public class Model
    {
        public string Title { get; set; }
        public Status StatusTask { get; set; }
        public string Detail { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Priority Priority { get; set; }
    }


}