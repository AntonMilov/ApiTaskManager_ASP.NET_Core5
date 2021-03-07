using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList2.Controllers.Abstract;
using TaskList2.Models;
using TaskList2.Repositories.Abstract;

namespace TaskList2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TaskController : ApiCrudControllerBase<Entities.Task, TaskModel>
    {
        IHistoryTaskRepository historyTaskRepository;
        public TaskController(IHistoryTaskRepository historyTaskRepository, ITaskRepository rep, IMapper mapper) : base(mapper)
        {
            this.historyTaskRepository = historyTaskRepository;
            this.rep = rep;
        }

        [HttpPost("UpdateStatusTask")]
        public IActionResult Post(HistoryTaskModel value)
        {
            var model = _mapper.Map<Entities.HistoryTask>(value);
            historyTaskRepository.Create(model);
            return Ok();
        }
        [HttpGet("GetHistoryForTask")]
        public IEnumerable<Entities.HistoryTask> GetHistory(Guid IdTask)
        {
            return historyTaskRepository.GetAllById(IdTask);
        }
    }
}
