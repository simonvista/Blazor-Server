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
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {
            try
            {
                return Ok(await _departmentRepository.GetDepartments());
            }
            catch (Exception )
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "Failed to retrieve departments from DB");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {
            try
            {
                var res = await _departmentRepository.GetDepartment(id);
                if (res==null)
                {
                    return NotFound();
                }
                else
                {
                    return res;
                }
            }
            catch (Exception )
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    "failed to retrieve department from DB based on id you provided");
            }
        }
    }
}
