using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;
using UsersAPI.Context;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/v1/UserProperties")]
    public class UserPropertiesController : ODataController
    {
        private readonly ILogger<UserPropertiesController> _logger;
        private readonly UsersContext _context;
        private readonly IMapper _mapper;

        public UserPropertiesController(ILogger<UserPropertiesController> logger, UsersContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet(Name = "GetUserProperties")]
        public IEnumerable<UserPropertyDto> Get([FromQuery] string key)
        {
            return _context.UserProperties.AsNoTracking().Where(up => up.UserId == key).Select(up => _mapper.Map<UserPropertyDto>(up));
        }

        [HttpPost(Name = "PostUserProperty")]
        public IActionResult Post([FromBody] UserPropertyPostDto userProperty)
        {
            if (userProperty == null || string.IsNullOrEmpty(userProperty.Key))
                return BadRequest();

            _context.UserProperties.Add(_mapper.Map<UserProperty>(userProperty));
            _context.SaveChanges();

            return Created("", userProperty);
        }

        [HttpDelete(Name = "DeleteUserProperty")]
        public IActionResult DeleteSingle([FromQuery] string userId, [FromQuery] string propertyKey)
        {
            var userToDelete = _context.UserProperties.Where(u => u.Key == propertyKey && u.UserId == userId);
            _context.RemoveRange(userToDelete);
            _context.SaveChanges();

            return Ok();
        }
    }
}
