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
    [Route("/v1/LicenseTypes")]
    public class LicenseTypesController : ODataController
    {
        private readonly ILogger<LicenseTypesController> _logger;
        private readonly LicensesContext _context;
        private readonly IMapper _mapper;

        public LicenseTypesController(ILogger<LicenseTypesController> logger, LicensesContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        [EnableQuery]
        [HttpGet(Name = "GetLicenses")]
        public IEnumerable<Models.LicenseType> Get()
        {
            return _context.LicenseTypes.AsNoTracking();
        }
    }
}