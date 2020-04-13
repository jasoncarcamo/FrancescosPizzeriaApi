using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrancescosPizzeriaApi.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int? EmployeeId {get; set;}
        public string? Position { get; set; }
        public decimal? Wage { get; set; }
        public string? Pin { get; set; }
        public DateTime? DateCreated { get; set; }
 
    }
}
