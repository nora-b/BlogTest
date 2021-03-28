﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string RememberMe { get; set; }
    }
}
