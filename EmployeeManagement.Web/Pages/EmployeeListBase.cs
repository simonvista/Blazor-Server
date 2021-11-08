﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }
        protected override Task OnInitializedAsync()
        {
            LoadEmployees();
            return base.OnInitializedAsync();
        }

        private void LoadEmployees()
        {
            Employee e1 = new Employee
            {
                EmployeeId = 1,
                FirstName = "John",
                LastName = "Hasting",
                Email = "David@pragimteach.com",
                DateOfBirth = new DateTime(1980, 10, 5),
                Gender = Gender.Male,
                Department = new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "HR"
                },
                PhotoPath = "images/john.jpg"
            };
            Employee e2 = new Employee
            {
                EmployeeId = 2,
                FirstName = "Sam",
                LastName = "Galloway",
                Email = "sam@pragimteach.com",
                DateOfBirth = new DateTime(1981, 12, 22),
                Gender = Gender.Male,
                Department = new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "IT"
                },
                PhotoPath = "images/sam.jpg"
            };
            Employee e3 = new Employee
            {
                EmployeeId = 3,
                FirstName = "Mary",
                LastName = "Smith",
                Email = "mary@pragimteach.com",
                DateOfBirth = new DateTime(1979, 11, 11),
                Gender = Gender.Female,
                Department = new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "IT"
                },
                PhotoPath = "images/mary.jpg"
            };
            Employee e4 = new Employee
            {
                EmployeeId = 4,
                FirstName = "Sara",
                LastName = "Longway",
                Email = "sara@pragimteach.com",
                DateOfBirth = new DateTime(1982, 9, 23),
                Gender = Gender.Female,
                Department = new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "HR"
                },
                PhotoPath = "images/sara.jpg"
            };
            Employees = new List<Employee> {e1, e2, e3, e4};
        }

    }
}
