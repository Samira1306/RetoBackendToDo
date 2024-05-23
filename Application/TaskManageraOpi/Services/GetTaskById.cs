using Application.Interface;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.TaskManageraOpi.Services
{
    public class GetTaskById : IGetTaskById
    {
        private readonly IRepository _repository;
        public GetTaskById(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<TaskManagerModel> GetTask(string id)
        {
            return await _repository.GetTaskOne(id);
        }

    }
}
