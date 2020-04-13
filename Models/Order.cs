using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using FrancescosPizzeriaApi.Models;

namespace FrancescosPizzeriaApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateCreated {get; set;}

        public MenuItem[] MenuItem { get; set; }
        
        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
