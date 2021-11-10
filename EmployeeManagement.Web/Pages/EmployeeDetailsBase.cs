using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject] public IEmployeeService EmployeeService { get; set; }
        public Employee Employee { get; set; } = new Employee();
        protected override async Task OnInitializedAsync()
        {
            Id = Id ?? "1";
            Employee= await EmployeeService.GetEmployee(int.Parse(Id));
        }
    }
}
