using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using TasksAPI.Context;
using TasksAPI.Models;

namespace TasksAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/v1/Tasks")]
    public class TasksController : ODataController
    {
        private readonly ILogger<TasksController> _logger; 
        private readonly TasksContext _context;
        private readonly IMapper _mapper;

        public TasksController(ILogger<TasksController> logger, TasksContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet(Name = "GetTasks")]
        public IEnumerable<TaskDto> Get([FromQuery] long key)
        {
            return _context.Tasks.AsNoTracking().Where(t => t.TenantId == key).Select(t => _mapper.Map<TaskDto>(t));
        }

        [HttpPost(Name = "PostTask")]
        public IActionResult Post([FromBody] TaskPostDto task)
        {
            if (task == null)
                return BadRequest();

            _context.Tasks.Add(_mapper.Map<Models.Task>(task));
            _context.SaveChanges();

            return Created("", task);
        }

        [HttpDelete(Name = "DeleteTask")]
        public IActionResult DeleteSingle([FromQuery] string key)
        {
            var taskToDelete = _context.Tasks.Where(u => u.Id == key);
            _context.RemoveRange(taskToDelete);
            _context.SaveChanges();

            return Ok();
        }
    }
}