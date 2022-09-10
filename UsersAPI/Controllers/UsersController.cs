using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using UsersAPI.Models;
using WebApi.Helpers;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("/v1/Users")]
    public class UsersController : ODataController
    {
        private readonly ILogger<UsersController> _logger;
        private readonly UsersContext _context;
        private readonly IMapper _mapper;

        public UsersController(ILogger<UsersController> logger, UsersContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<UserDto> Get()
        {
            return _context.Users.AsNoTracking().Select(u => _mapper.Map<UserDto>(u));
        }

        [HttpPost(Name = "PostUser")]
        public IActionResult Post([FromBody] UserPostDto user)
        {
            if (user == null || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Surname) || string.IsNullOrEmpty(user.Email))
                return BadRequest();

            _context.Users.Add(_mapper.Map<User>(user));
            _context.SaveChanges();

            return Created("", user);
        }

        [HttpDelete(Name = "DeleteUser")]
        public IActionResult DeleteSingle([FromQuery] string key)
        {
            var userToDelete = _context.Users.Where(u => u.Id == key);
            _context.RemoveRange(userToDelete);
            _context.SaveChanges();

            return Ok();
        }
    }
}