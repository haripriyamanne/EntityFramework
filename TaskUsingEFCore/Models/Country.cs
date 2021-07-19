using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TaskUsingEFCore.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [Display(Name ="Country Name")]
        public string CountryName { get; set; }


        public int stateId { get; set; }


        [ForeignKey("stateId")]
        public State states { get; set; }
    }
}
