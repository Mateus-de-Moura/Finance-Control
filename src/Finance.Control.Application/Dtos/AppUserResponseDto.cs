﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Application.Dtos
{
    public sealed class AppUserResponseDto
    {
        public Guid Id { get; set; }
        public Guid AppRoleId { get; set; }
        public bool IsActive { get; set; }
        public string Name { get; set; }
        public string Email { get; set; } 
        public string Role { get; set; }       
    }
}
