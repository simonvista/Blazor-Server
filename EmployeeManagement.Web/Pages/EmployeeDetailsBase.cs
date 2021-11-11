using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Parameter]
        public string Id { get; set; }
        [Inject] public IEmployeeService EmployeeService { get; set; }
        public Employee Employee { get; set; } = new Employee();
        protected string Coordinates { get; set; }  //EmployeeDetails.razor can access Coordinates
        protected override async Task OnInitializedAsync()  
        {
            Id = Id ?? "1";
            Employee= await EmployeeService.GetEmployee(int.Parse(Id));
        }

        protected void Mouse_Mouve(MouseEventArgs e)
        {
            Coordinates = $"x: {e.ClientX}, y: {e.ClientY}";
        }
    }
}
