using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            //helper method:http status code
            //OK:200,Created:201,NoContent:204,BadRequest:400,UnAuthorized:401,NotFound:404,StatusCode:50x
            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }
            catch (Exception)
            {

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Failed to retrieve employees from DB");
            }
        }
    }
}
