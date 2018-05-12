using EMS.Api.DomainModels;
using EMS.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EMS.Api.Controllers
{
    [Route("api/City")]
    public class CityController : Controller
    {
        readonly IRepository<City> _cityRepository;
        readonly ILogger<CityController> _log;

        public CityController(IRepository<City> cityRepository, ILogger<CityController> logger)
        {
            _cityRepository = cityRepository;
            _log = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var city = _cityRepository.Get();

                if (city == null) return new NotFoundResult();

                return Ok(city);
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode(500);
            }
        }
    }
}