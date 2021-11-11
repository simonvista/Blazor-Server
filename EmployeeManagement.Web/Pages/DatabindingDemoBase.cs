using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DatabindingDemoBase : ComponentBase
    {
        //data binding to property
        protected string Name { get; set; } = "Tom";
        protected string Gender { get; set; } = "Male";
        protected string Color { get; set; } = "background-color:white";
    }
}
