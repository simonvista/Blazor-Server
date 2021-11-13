﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models.CustomValidators
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }
        protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
        {
            string[] strings = value.ToString().Split('@');
            //if (strings[1].ToLower() == "pragimtech.com")
            if (strings.Length>1 && strings[1].ToLower() == AllowedDomain.ToLower())
            {
                return null;
            }

            return new ValidationResult(
                //"Domain must be pragimtech.com",
                ErrorMessage, new[] {validationContext.MemberName});
        }
    }
}
