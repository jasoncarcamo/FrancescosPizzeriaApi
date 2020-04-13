using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrancescosPizzeriaApi.Data;
using FrancescosPizzeriaApi.Models;

namespace FrancescosPizzeriaApi.Data
{
    public static class SeedEmployees
    {
        public static void Initialize(FrancescosPizzeriaContext context)
        {
            if (!context.Employee.Any())
            {
                context.Employee.AddRange(
                    new Employee
                    {
                        EmployeeId = 1234,
                        DateCreated = DateTime.Now,
                        Position = "Admin",
                        Pin = "AQAAAAEAACcQAAAAEJ9eyHh/9mK4+8Hk803K94P3HVd9t4mDkeWzWSFNdAT5Nm6NK3arYPnvTZcTksNN/w==",
                        Wage = 20.00m
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
