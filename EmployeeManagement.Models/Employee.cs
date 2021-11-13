using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EmployeeManagement.Models.CustomValidators;

namespace EmployeeManagement.Models
{
    public class Employee
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
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        //public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        //navigation properties
        public Department Department { get; set; }
    }
}
