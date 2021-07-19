﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskUsingEFCore.Models
{
    public class State
    {

       
        [Key]
        public int StateId { get; set; }

        [Required]
        public string StateName { get; set; }
        public int CountryId { get; set; }
    }
}
