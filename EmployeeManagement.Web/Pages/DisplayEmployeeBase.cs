﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase : ComponentBase
    {
        //denote the target member as component parameter which can be passed from parent component (EmployeeList component)
        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }
        [Inject] public IEmployeeService EmployeeService { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        protected async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool) e.Value);
        }
        protected async Task Delete_Click()
        {
            await EmployeeService.DeleteEmployee(Employee.EmployeeId);
            NavigationManager.NavigateTo("/",true);
        }
    }
}
