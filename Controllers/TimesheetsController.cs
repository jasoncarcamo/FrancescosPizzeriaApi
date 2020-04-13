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

namespace FrancescosPizzeriaApi.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TimesheetsController : ControllerBase
    {
        private readonly FrancescosPizzeriaContext _context;

        public TimesheetsController(FrancescosPizzeriaContext context)
        {
            _context = context;
        }

        [HttpGet("isclockedin/{employeeId}")]
        public async Task<ActionResult<Timesheet>> IsClockedIn(int employeeId)
        {
            Employee employee = _context.Employee.FirstOrDefault(i => i.EmployeeId == employeeId);

            if(employee == null)
            {
                return NotFound(new { error = "Employee does not exist"});
            }

            Timesheet timesheet = _context.TimeSheet.FirstOrDefault(x => x.Employee_id == employeeId && x.Date.Day.Equals(DateTime.Now.Day) == true && x.ClockedIn == true);

            if(timesheet == null)
            {
                return BadRequest( new { error = "Employee is not clocked in"});
            };

            return Ok( new { success = $"Employee: {employeeId} is clocked in"});
        }

        // GET: api/Timesheets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Timesheet>>> GetTimeSheet()
        {
            return await _context.TimeSheet.ToListAsync();
        }

        // GET: api/Timesheets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Timesheet>> GetTimesheet(int id)
        {
            var timesheet = await _context.TimeSheet.FindAsync(id);

            if (timesheet == null)
            {
                return NotFound();
            }

            return timesheet;
        }

        // PATCH: api/Timesheets/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPatch("{id}")]
        public async Task<IActionResult> PutTimesheet(int id, Timesheet timesheet)
        {
            if (id != timesheet.Id)
            {
                return BadRequest();
            }

            _context.Entry(timesheet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimesheetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPatch("edit/{employee_id}")]
        public async Task<IActionResult> PatchTimesheet(int employee_id, Timesheet timesheet)
        {

            Employee employee = _context.Employee.FirstOrDefault( i => i.EmployeeId == employee_id);

            Timesheet patchTimesheet = timesheet;
            Timesheet currentTimesheet = _context.TimeSheet.FirstOrDefault( x => x.Employee_id == employee.Id && x.Date.Day == DateTime.Now.Day);


            if(employee == null)
            {
                return NotFound(new { error = "Employee was not found"});
            };

            if(currentTimesheet == null)
            {
                return NotFound( new { error = $"No time sheet was found today for {employee.Id} or is not clocked in"});
            }

            TimeSpan time = DateTime.Now - currentTimesheet.Date;

            if (patchTimesheet.ClockedIn != null)
            {
                currentTimesheet.ClockedIn = patchTimesheet.ClockedIn;
                
                if(patchTimesheet.ClockedIn == false)
                {
                    time = DateTime.Now - currentTimesheet.Date;
                    currentTimesheet.Hours += (decimal)time.TotalHours;
                }
            }

            if (patchTimesheet.ClockedOutAt != null)
            {
                currentTimesheet.ClockedOutAt = patchTimesheet.ClockedOutAt;

            }

            if (patchTimesheet.OnBreak != null)
            {
                currentTimesheet.OnBreak = patchTimesheet.OnBreak;

                if(patchTimesheet.OnBreak == true)
                {
                    time = DateTime.Now - currentTimesheet.Date;
                    currentTimesheet.Hours += (decimal)time.TotalHours;
                };
            }

            if(patchTimesheet.OnBreakAt != null)
            {
                currentTimesheet.OnBreakAt = patchTimesheet.OnBreakAt;
            }

            if(patchTimesheet.OffBreakAt != null)
            {
                currentTimesheet.OffBreakAt = patchTimesheet.OffBreakAt;
            }
            

            _context.TimeSheet.Update(currentTimesheet);


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TimesheetExists(currentTimesheet.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok( new { success = "Employee has been updated" });
        }

        // POST: api/Timesheets
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Timesheet>> PostTimesheet(Timesheet timesheet)
        {
            Timesheet newTimesheet = timesheet;

            newTimesheet.Hours = 0;
            newTimesheet.OnBreak = false;
            newTimesheet.HadBreak = false;
            newTimesheet.ClockedIn = true;
            newTimesheet.ClockedInAt = DateTime.Now;
            newTimesheet.Date = DateTime.Now;

            _context.TimeSheet.Add(timesheet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTimesheet", new { id = timesheet.Id }, timesheet);
        }

        // DELETE: api/Timesheets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Timesheet>> DeleteTimesheet(int id)
        {
            var timesheet = await _context.TimeSheet.FindAsync(id);
            if (timesheet == null)
            {
                return NotFound();
            }

            _context.TimeSheet.Remove(timesheet);
            await _context.SaveChangesAsync();

            return timesheet;
        }

        private bool TimesheetExists(int id)
        {
            return _context.TimeSheet.Any(e => e.Id == id);
        }
    }
}
