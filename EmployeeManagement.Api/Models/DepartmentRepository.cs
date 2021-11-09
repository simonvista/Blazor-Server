using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;

        public DepartmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _appDbContext.Departments;
        }

        public Department GetDepartment(int departmentId)
        {
            return _appDbContext.Departments.FirstOrDefault(
                d=>d.DepartmentId==departmentId);
        }
    }
}
