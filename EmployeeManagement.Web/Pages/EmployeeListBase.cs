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
        [Inject] 
        public IEmployeeService EmployeeService { get; set; }
        protected IEnumerable<Employee> Employees { get; set; }

        protected bool ShowFooter { get; set; } = true;

        protected int SelectedEmployeesCount { get; set; } = 0;
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
        //event handler
        protected void EmployeeSelectionChanged(bool isSelected)
        {
            if (isSelected)
            {
                SelectedEmployeesCount++;
            }
            else
            {
                SelectedEmployeesCount--;
            }
        }
        //event handler
        protected async Task EmployeeDeleted()
        {
            Employees = (await EmployeeService.GetEmployees()).ToList();
        }
    }
}
