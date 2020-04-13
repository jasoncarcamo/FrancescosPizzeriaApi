using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrancescosPizzeriaApi.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SizeReg { get; set; }
        public string SizeSmall { get; set; }
        public decimal PriceReg { get; set; }
        public decimal PriceSmall { get; set; }
        public string Ingredients { get; set; }
    }
}
