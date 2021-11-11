using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        //inject service -> no inject service through constructor
        [Inject] public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

        public bool ShowFooter { get; set; } = true;
        //protected override Task OnInitializedAsync()
        //{
        //    LoadEmployees();
        //    return base.OnInitializedAsync();
        //}
        protected override async Task OnInitializedAsync()
        {
            //await Task.Run(LoadEmployees);
            Employees= (await EmployeeService.GetEmployees()).ToList();
        }

        //private void LoadEmployees()
        //{
        //    System.Threading.Thread.Sleep(3000);
        //    Employee e1 = new Employee
        //    {
        //        EmployeeId = 1,
        //        FirstName = "John",
        //        LastName = "Hasting",
        //        Email = "David@pragimteach.com",
        //        DateOfBirth = new DateTime(1980, 10, 5),
        //        Gender = Gender.Male,
        //        DepartmentId = 1,
        //        PhotoPath = "images/john.jpg"
        //    };
        //    Employee e2 = new Employee
        //    {
        //        EmployeeId = 2,
        //        FirstName = "Sam",
        //        LastName = "Galloway",
        //        Email = "sam@pragimteach.com",
        //        DateOfBirth = new DateTime(1981, 12, 22),
        //        Gender = Gender.Male,
        //        DepartmentId = 2,
        //        PhotoPath = "images/sam.jpg"
        //    };
        //    Employee e3 = new Employee
        //    {
        //        EmployeeId = 3,
        //        FirstName = "Mary",
        //        LastName = "Smith",
        //        Email = "mary@pragimteach.com",
        //        DateOfBirth = new DateTime(1979, 11, 11),
        //        Gender = Gender.Female,
        //        DepartmentId = 1,
        //        PhotoPath = "images/mary.jpg"
        //    };
        //    Employee e4 = new Employee
        //    {
        //        EmployeeId = 4,
        //        FirstName = "Sara",
        //        LastName = "Longway",
        //        Email = "sara@pragimteach.com",
        //        DateOfBirth = new DateTime(1982, 9, 23),
        //        Gender = Gender.Female,
        //        DepartmentId = 3,
        //        PhotoPath = "images/sara.jpg"
        //    };
        //    Employees = new List<Employee> {e1, e2, e3, e4};
        //}

    }
}
