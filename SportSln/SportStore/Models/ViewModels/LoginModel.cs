﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportStore.Models.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }
        public string Password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}
