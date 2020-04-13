using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrancescosPizzeriaApi.Data;
using FrancescosPizzeriaApi.Models;

namespace FrancescosPizzeriaApi.Data
{
    public static class SeedInventory
    {
        public static void Initialize(FrancescosPizzeriaContext context)
        {
            if (!context.Inventory.Any())
            {
                context.Inventory.AddRange(
                    new Inventory
                    {
                        Title = "Pepperoni",
                        Used_for = "Pizza",
                        Left = 1000
                    },
                    new Inventory
                    {
                        Title = "Mozzarella cheese",
                        Used_for = "Pizza, Pasta",
                        Left = 1000
                    },
                    new Inventory
                    {
                        Title = "Grated cheese",
                        Used_for = "Pizza, Pasta",
                        Left = 1000
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
