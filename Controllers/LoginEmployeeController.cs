using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrancescosPizzeriaApi.Data;
using FrancescosPizzeriaApi.Models;
using Microsoft.AspNetCore.Authorization;
using FrancescosPizzeriaApi.Services;
using Microsoft.Extensions.Configuration;
using FrancescosPizzeriaApi.Models;

namespace FrancescosPizzeriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginEmployeeController : ControllerBase
    {
        private readonly FrancescosPizzeriaContext _context;

        public IConfiguration Configuration { get; }
        public LoginEmployeeController(FrancescosPizzeriaContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        // GET: api/Login
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {

            return Ok( new { user = User.Identity.Name });
        }

        // POST: api/Login
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            EmployeeService employeeService = new EmployeeService(Configuration);

            Employee currentEmployee = employee;
            Employee dbEmployee = _context.Employee.FirstOrDefault(x => x.EmployeeId == currentEmployee.EmployeeId);

            if(dbEmployee == null)
            {
                return NotFound(new { error = "No employee was found" });
            }

            bool matches = employeeService.ComparePin(currentEmployee, currentEmployee.Pin, dbEmployee.Pin);

            if (!matches)
            {
                return BadRequest(new { error = "Wrong pin" });
            }

            return Ok( new { token = employeeService.createToken(dbEmployee)});
        }
    }
}
