using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DatabindingDemo1Base :ComponentBase
    {
        public string Description { get; set; } = string.Empty;
    }
}
