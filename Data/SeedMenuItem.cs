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
                    },
                    new MenuItem
                    {
                        Category = "Pasta",
                        Title = "Alfredo pasta",
                        Description = "Creamy alfredo sauce with grated parmigiano cheese",
                        Ingredients = "Alfredo sauce, Grated cheese",
                        SizeReg = "Regular",
                        SizeSmall = "Small",
                        PriceReg = 12.25m,
                        PriceSmall = 5.95m
                    },
                    new MenuItem
                    {
                        Category = "Pasta",
                        Title = "Baked ziti",
                        Description = "Penne mixed with tomato sauce, ricotta, and topped with mozzarella cheese",
                        Ingredients = "Tomato sauce, Ricotta, Mozzarella cheese",
                        SizeReg = "Regular",
                        SizeSmall = "Small",
                        PriceReg = 11.95m,
                        PriceSmall = 5.95m
                    },
                    new MenuItem
                    {
                        Category = "Pasta",
                        Title = "Penne al vodka",
                        Description = "Creamy pink vodka with diced imported proscuitto and onion",
                        Ingredients = "Vodka sauce, Diced prosciutto, Onion",
                        SizeReg = "Regular",
                        SizeSmall = "Small",
                        PriceReg = 11.95m,
                        PriceSmall = 5.95m
                    },
                    new MenuItem
                    {
                        Category = "Hero",
                        Title = "Chicken parmagiana hero",
                        Description = "Fried breaded chicken cutlet topped with tomato sauce, and melted mozzarella cheese",
                        Ingredients = "Fried chicken cutlet, Tomato sauce, Mozzarella cheese",
                        SizeReg = "Regular",
                        SizeSmall = "Small",
                        PriceReg = 11.95m,
                        PriceSmall = 6.95m
                    },
                    new MenuItem
                    {
                        Category = "Hero",
                        Title = "Meatball parmagiana hero",
                        Description = "$ meatballs topped with tomato sauce, and melted mozzarella cheese",
                        Ingredients = "Meatballs, Tomato sauce, Mozzarella cheese",
                        SizeReg = "Regular",
                        SizeSmall = "Small",
                        PriceReg = 11.95m,
                        PriceSmall = 6.95m
                    },
                    new MenuItem
                    {
                        Category = "Hero",
                        Title = "Veal parmagiana hero",
                        Description = "Fried breaded veal topped with tomato sauce, and melted mozzarella cheese",
                        Ingredients = "Veal, Tomato sauce, Mozzarella cheese",
                        SizeReg = "Regular",
                        SizeSmall = "Half",
                        PriceReg = 10.45m,
                        PriceSmall = 6.95m
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
