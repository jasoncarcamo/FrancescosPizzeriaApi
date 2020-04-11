using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrancescosPizzeriaApi.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Used_for { get; set; }
        public int Left { get; set; }
        
    }
}
