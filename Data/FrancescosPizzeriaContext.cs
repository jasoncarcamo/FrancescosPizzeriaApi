using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FrancescosPizzeriaApi.Models;


namespace FrancescosPizzeriaApi.Data
{
    public class FrancescosPizzeriaContext : DbContext
    {
        public FrancescosPizzeriaContext(DbContextOptions<FrancescosPizzeriaContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<Timesheet> TimeSheet { get; set; }

    }
}
