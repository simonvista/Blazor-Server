using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Api.Models;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _appDbContext.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(
                e => e.EmployeeId == employeeId);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var res= await _appDbContext.Employees.AddAsync(employee);
            await _appDbContext.SaveChangesAsync();
            return res.Entity;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var emp= await _appDbContext.Employees.FirstOrDefaultAsync(
                e=>e.EmployeeId==employee.EmployeeId);
            if (emp!=null)
            {
                emp.FirstName = employee.FirstName;
                emp.LastName = employee.LastName;
                emp.Email = employee.Email;
                emp.DateOfBirth = employee.DateOfBirth;
                emp.Gender = employee.Gender;
                emp.DepartmentId = employee.DepartmentId;
                emp.PhotoPath = employee.PhotoPath;
                await _appDbContext.SaveChangesAsync();
                return emp;
            }

            return null;
        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var employee=await _appDbContext.Employees.FirstOrDefaultAsync(
                e=>e.EmployeeId==employeeId);
            if (employee!=null)
            {
                _appDbContext.Employees.Remove(employee);
                await _appDbContext.SaveChangesAsync();
                return employee;
            }

            return null;
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await _appDbContext.Employees.FirstOrDefaultAsync(
                e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = _appDbContext.Employees;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(
                    e => e.FirstName.Contains(name) || 
                         e.LastName.Contains(name));
            }

            if (gender!=null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }
    }
}
