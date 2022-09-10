using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
//using System.Web.Http;
//using System.Web.Http.OData;
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
        public UsersController(ILogger<UsersController> logger, UsersContext context)
        {
            _logger = logger;
            _context = context;
        }

        [EnableQuery]
        [HttpGet(Name = "GetAllUsers")]
        public IEnumerable<User> Get()
        {
            return _context.Users;
        }

        [HttpPost(Name = "PostUser")]
        public IActionResult Post([FromBody] User user)
        {
            if (user == null || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Surname) || string.IsNullOrEmpty(user.Email))
                return BadRequest();

            user.Id = Guid.NewGuid().ToString();
            _context.Users.Add(user);
            _context.SaveChanges();

            return Created("", user);
        }
    }
}