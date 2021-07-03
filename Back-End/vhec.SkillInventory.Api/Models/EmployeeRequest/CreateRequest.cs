﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using vhec.SkillInventory.DAL.Enums;

namespace vhec.SkillInventory.Api.Models.EmployeeRequest
{
    public class CreateRequest
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [MaxLength(250)]
        [Required]
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public JobPosition JobPosition { get; set; }
    }
}
