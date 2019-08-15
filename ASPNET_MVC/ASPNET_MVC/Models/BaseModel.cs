﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET_MVC.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="This field is required.")]
        public string Name { get; set; }
    }
}
