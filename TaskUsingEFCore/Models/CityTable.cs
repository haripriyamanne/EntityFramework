using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskUsingEFCore.Models
{
    public class CityTable
    {
        [Key]
        public int CityId { get; set; }

        [Required]
        public string CityName { get; set; }
        public int StateId { get; set; }
    }
}
