using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrancescosPizzeriaApi.Data;
using FrancescosPizzeriaApi.Models;

namespace FrancescosPizzeriaApi.Data
{
    public static class SeedMenuItem
    {
        public static void Initialize(FrancescosPizzeriaContext context)
        {
            if (!context.MenuItem.Any())
            {
                context.MenuItem.AddRange(
                    new MenuItem
                    {
                        Category = "Pizza",
                        Title = "Neopolitan pizza",
                        Description = "Regular round pizza with tomato sauce, mozzarella cheese, grated cheese, and oregano",
                        Ingredients = "Tomato sauce, Mozzarela cheese, Grated cheese, Oregano",
                        SizeReg = "Regular",
                        SizeSmall = "Small",
                        PriceReg = 14.95m,
                        PriceSmall = 10.45m
                    },
                    new MenuItem
                    {
                        Category = "Pizza",
                        Title = "Margherita pizza",
                        Description = "Fresh mozzarella cheese, fresh marinara sauce, basil, oregano, extra virgin oil",
                        Ingredients = "Fresh mozzarella cheese, Fresh marinara sauce, Basil, Oregano, Virgin oil",
                        SizeReg = "Regular",
                        SizeSmall = "Small",
                        PriceReg = 17.45m,
                        PriceSmall = 10.45m
                    },
                    new MenuItem
                    {
                        Category = "Pizza",
                        Title = "Sicilian pizza",
                        Description = "Thick and light square pizza with our special sauce and melted mozzarela with grated cheese and oregano",
                        Ingredients = "Special sauce, Mozzarella cheese, Grated cheese, Oregano",
                        SizeReg = "Regular",
                        SizeSmall = "None",
                        PriceReg = 17.45m,
                        PriceSmall = 0.00m
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
