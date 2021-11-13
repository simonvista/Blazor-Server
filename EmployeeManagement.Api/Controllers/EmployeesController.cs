using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController] will check if model state is valid
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var res = await _employeeRepository.GetEmployee(id);
                if (res == null)
                {
                    return NotFound();
                }

                return res;
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Failed to retrieve employee from DB");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if (employee==null)
                {
                    return BadRequest();
                }

                var emp= await _employeeRepository.GetEmployeeByEmail(employee.Email);
                if (emp!=null)
                {
                    ModelState.AddModelError("email","Employee email is already in system");
                    return BadRequest(ModelState);
                }
                var addEmployee = await _employeeRepository.AddEmployee(employee);
                return CreatedAtAction(
                    nameof(GetEmployee),
                    new {id = addEmployee.DepartmentId},
                    addEmployee);
            }
            catch (Exception)
            {

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Failed to create employee in DB");
            }
        }
        //[HttpPut("{id:int}")]
        [HttpPut]
        //public async Task<ActionResult<Employee>> UpdateEmployee(
        //    int id,Employee employee)
        //public async Task<ActionResult<Employee>> UpdateEmployee(
        //    int id, Employee employee)
        public async Task<ActionResult<Employee>> UpdateEmployee(Employee employee)
        {
            try
            {
                //if (id!=employee.EmployeeId)
                //{
                //    return BadRequest("Employee id your provided doesn't math with the one in DB");
                //}

                var emp=await _employeeRepository.GetEmployee(employee.EmployeeId);
                if (emp==null)
                {
                    return NotFound($"Employee with id={employee.EmployeeId} not found in DB");
                }

                return await _employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Failed to update employee in DB");
            }
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var emp=await _employeeRepository.GetEmployee(id);
                if (emp==null)
                {
                    return NotFound($"Employee with id={id} not found in DB");
                }
                return await _employeeRepository.DeleteEmployee(id);
            }
            catch (Exception )
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Failed to delete employee from DB");
            }
        }
        //base_url/api/employees/search/<name>/<gender>
        //[HttpGet("{search}/{name}/{gender}?}")]
        //base_url/api/employees/search?name=**&gender=**
        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Employee>>> Search(
            string name, Gender? gender)
        {
            try
            {
                var res = await _employeeRepository.Search(name, gender);
                if (res.Any())
                {
                    return Ok(res);
                }

                return NotFound();
            }
            catch (Exception )
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Failed to retrieve employees in DB based on your queries");
            }
        }
    }
}
