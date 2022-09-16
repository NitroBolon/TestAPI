using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using TenantsAPI.Context;
using TenantsAPI.Models;

namespace TenantsAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/v1/Tenants")]
    public class TenantsController : ODataController
    {
        private readonly ILogger<TenantsController> _logger;
        private readonly IMapper _mapper;
        private readonly TenantsContext _context;

        public TenantsController(ILogger<TenantsController> logger, IMapper mapper, TenantsContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

        [EnableQuery]
        [HttpGet(Name = "GetUserTenants")]
        public IEnumerable<Tenant> Get()
        {
            return _context.Tenants.AsNoTracking();
        }
    }
}