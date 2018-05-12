using EMS.Api.DomainModels;
using EMS.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace EMS.Api.Controllers
{
    [Route("api/Employee")]
    public class EmployeeController : Controller
    {
        readonly IRepository<Employee> _employeeRepository;
        readonly ILogger<EmployeeController> _log;

        public EmployeeController(IRepository<Employee> employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _log = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var emp = _employeeRepository.Get();

                if (emp == null) return new NotFoundResult();

                return Ok(emp);
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode(500);
            }

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var emp = _employeeRepository.Get(id);

                if (emp == null) return new NotFoundResult();

                return Ok(emp);
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode(500);
            }
        }

        [HttpPost("Add")]
        public IActionResult Post([FromBody]Employee entity)
        {
            try
            {
                _employeeRepository.Add(entity);
                _log.LogInformation("Employee Inserted Successfully");
                return Ok("Success");
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode(500);
            }
        }

        [HttpPut("Update")]
        public IActionResult Put([FromBody]Employee entity)
        {
            try
            {
                _employeeRepository.Update(entity);
                return Ok("Success");
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode(500);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _employeeRepository.Delete(id);
                _log.LogInformation("Employee " + id + " deleted Successfully");
                return Ok();
            }
            catch (Exception e)
            {
                _log.LogError(e.ToString());
                return StatusCode(500);
            }
        }

    }
}