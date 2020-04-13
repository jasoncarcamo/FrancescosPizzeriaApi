using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrancescosPizzeriaApi.Data;
using FrancescosPizzeriaApi.Models;

namespace FrancescosPizzeriaApi.Data
{
    public static class SeedTimeSheet
    {
        public static void Initialize(FrancescosPizzeriaContext context)
        {
            if (!context.TimeSheet.Any())
            {
                context.TimeSheet.AddRange(
                    new Timesheet
                    {
                        Hours = 2.5m,
                        ClockedIn = true,
                        OnBreak = false,
                        HadBreak = true,
                        ClockedInAt = DateTime.Now,
                        Date = DateTime.Now,
                        Employee_id = 1005
                    }
                );
            }

            context.SaveChanges();
        }
    }
}
