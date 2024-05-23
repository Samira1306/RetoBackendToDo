using Domain.Enums;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskManageraOpi
{
    public interface IEditTask
    {
        Task EditTaskStatus(string taskId, Status StatusTask);
    }
}
