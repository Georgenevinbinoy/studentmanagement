﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4
{
    public class Course
    {

        [Required]
        [StringLength(255)]
        public String Courses1    { get; set; }
        


    }
}
