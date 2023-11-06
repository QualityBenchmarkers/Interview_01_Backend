using Interview.Database.Configuration;
using Interview.Database.Entities.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Interview.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CityAndProvinceController : ControllerBase
    {


        private readonly ILogger<CityAndProvinceController> _logger;
        private readonly CommandCenterContext _context;

        public CityAndProvinceController(ILogger<CityAndProvinceController> logger , CommandCenterContext context)
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