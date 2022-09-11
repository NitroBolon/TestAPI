using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using TasksAPI.Context;
using TasksAPI.Models;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/v1/TaskStates")]
    public class TaskStatesController : ODataController
    {
        private readonly ILogger<TaskStatesController> _logger;
        private readonly TasksContext _context;
        private readonly IMapper _mapper;

        public TaskStatesController(ILogger<TaskStatesController> logger, TasksContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet(Name = "GetTaskStates")]
        public IEnumerable<TaskStateDto> Get([FromQuery] long key)
        {
            return _context.TaskStates.AsNoTracking().Where(ts => ts.TenantId == key).Select(ts => _mapper.Map<TaskStateDto>(ts));
        }

        [HttpPost(Name = "PostTaskState")]
        public IActionResult Post([FromBody] TaskStatePostDto state)
        {
            if (state == null)
                return BadRequest();

            _context.TaskStates.Add(_mapper.Map<TaskState>(state));
            _context.SaveChanges();

            return Created("", state);
        }

        [HttpDelete(Name = "DeleteTaskState")]
        public IActionResult DeleteSingle([FromQuery] long stateId, [FromQuery] long tenantId)
        {
            var stateToDelete = _context.TaskStates.Where(u => u.Id == stateId && u.TenantId == tenantId);
            _context.RemoveRange(stateToDelete);
            _context.SaveChanges();

            return Ok();
        }
    }
}
