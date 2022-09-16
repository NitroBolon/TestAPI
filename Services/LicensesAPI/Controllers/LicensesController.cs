using AutoMapper;
using LicensesAPI.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace LicensesAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/v1/Licenses")]
    public class LicensesController : ODataController
    {
        private readonly ILogger<LicensesController> _logger;
        private readonly LicensesContext _context;
        private readonly IMapper _mapper;

        public LicensesController(ILogger<LicensesController> logger, LicensesContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet(Name = "GetLicenses")]
        public IEnumerable<Models.License> Get()
        {
            return _context.Licenses.AsNoTracking();
        }
    }
}