using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Models
{
    public class EmployeeJob
    {
        [Key]
        public int ID { get; set; }
        public string Role { get; set; }
        public string Experience { get; set; }
    }
}
