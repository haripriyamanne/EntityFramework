using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeProject.Models
{
    public class EmployeeDetails
    {
        [Key]
        public int ID { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PostalCode { get; set; }
        public int JobID { get; set; }
        public EmployeeJob EmpJob { get; set; }

        [NotMapped]
        public IList<Employee> Employee { get; set; }
    }
}
