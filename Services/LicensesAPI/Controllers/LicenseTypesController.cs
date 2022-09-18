using AutoMapper;
using LicensesAPI.Context;
using LicensesAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace LicensesAPI.Controllers
{
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
        [HttpGet(Name = "GetLicenseTypes")]
        public IEnumerable<LicenseTypeDto> Get()
        {
            return _context.LicenseTypes.AsNoTracking().Where(lt => lt.IsOfferActive).OrderBy(lt => lt.Priority).Select(lt => _mapper.Map<LicenseTypeDto>(lt));
        }

        [Authorize]
        [HttpPost("PostLicenseType")]
        public IActionResult Post([FromBody] LicenseTypePostDto licenseType)
        {
            if (licenseType == null || string.IsNullOrWhiteSpace(licenseType.Name) || licenseType.ValidMonths < 1 || licenseType.PriceMonth < 0 || licenseType.Priority < 0)
            {
                return BadRequest();
            }

            _context.LicenseTypes.Add(new LicenseType
            {
                Name = licenseType.Name,
                ValidMonths = licenseType.ValidMonths,
                PriceMonth = licenseType.PriceMonth,
                Priority = licenseType.Priority,
                Subscriptions = licenseType.Subscriptions,
                IsOfferActive = false
            });
            _context.SaveChanges();

            return Ok();
        }

        [Authorize]
        [HttpPost("ActivateLicenseType")]
        public IActionResult PostActivate([FromQuery] long licenseId)
        {
            var license = _context.LicenseTypes.Where(lt => lt.Id == licenseId).FirstOrDefault();
            if (license == null || license == default)
            {
                return BadRequest();
            }

            license.IsOfferActive = true;
            _context.SaveChanges();

            return Ok();
        }

        [Authorize]
        [HttpPost("DeactivateLicenseType")]
        public IActionResult PostDeactivate([FromQuery] long licenseId)
        {
            var license = _context.LicenseTypes.Where(lt => lt.Id == licenseId).FirstOrDefault();
            if (license == null || license == default)
            {
                return BadRequest();
            }

            license.IsOfferActive = false;
            _context.SaveChanges();

            return Ok();
        }
    }
}