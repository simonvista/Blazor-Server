﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Models
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EditEmployeeModel>()
                .ForMember(
                    dest=>dest.ConfirmEmail,
                    opt=>opt.MapFrom(
                        src=>src.Email));
            CreateMap<EditEmployeeModel, Employee>();
        }
    }
}
