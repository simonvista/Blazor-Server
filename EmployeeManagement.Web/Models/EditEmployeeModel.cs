using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Models.CustomValidators;

namespace EmployeeManagement.Web.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "First Name can't be blank")]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(
            AllowedDomain = "PragimTech.com",
            ErrorMessage = "Only PragimTech.com is allowed")]
        public string Email { get; set; }
        [CompareProperty("Email",ErrorMessage = "Confirm email and email don't match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        //public Department Department { get; set; }
        [Required]
        public int? DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        //navigation properties (complex model)
        [ValidateComplexType]
        public Department Department { get; set; } = new Department();
    }
}
