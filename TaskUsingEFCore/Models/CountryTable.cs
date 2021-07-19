using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskUsingEFCore.Models
{
    public class CountryTable
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        public string CountryName { get; set; }

        [NotMapped]
        public int StateId { get; set; }
    }
}
