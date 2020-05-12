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
        public int PointsEarned { get; set; }
        public string OrderType { get; set; }
        public string Address { get; set; }

        public string MobileNumber { get; set; }
        public bool OrderComplete { get; set; }

        public DateTime Time { get; set; }
        public DateTime DateCreated {get; set;}
        
        [ForeignKey("User")]
        public int? UserId { get; set; }
    }
}
