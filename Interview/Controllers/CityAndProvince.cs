using Interview.Database.Configuration;
using Interview.Database.Entities.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Interview.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    //[Authorize]
    public class CityAndProvince // : ControllerBase
    {


        private readonly ILogger<CityAndProvince> _logger;
        private readonly CommandCenterContext _context;

        public CityAndProvince(ILogger<CityAndProvince> logger , CommandCenterContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("GetProvince")]
        public ActionResult<List<Province>> GetProvince()
        {
            var provinces = _context.Provinces.ToList();
            return provinces;
        }

        [HttpGet("GetCity")]
        public ActionResult<List<City>> GetCity()
        {
            var provinceCities =  _context.Cities.ToList();
            return provinceCities;
        }
       
    }
}