using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrancescosPizzeriaApi.Models
{
    public class Timesheet
    {
        public int Id { get; set; }
        public decimal Hours { get; set; }
        public bool ClockedIn { get; set; }
        public bool OnBreak { get; set; }

        [ForeignKey("Empolyee")]
        public int Employee_id { get; set; }
    }
}
