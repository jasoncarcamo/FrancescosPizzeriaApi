using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FrancescosPizzeriaApi.Data;
using FrancescosPizzeriaApi.Models;
using FrancescosPizzeriaApi.Services;
using Microsoft.Extensions.Configuration;

namespace FrancescosPizzeriaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly FrancescosPizzeriaContext _context;
        public IConfiguration Configuration { get; }

        public RegisterUserController(FrancescosPizzeriaContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        // POST: api/Register
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            UserService userService = new UserService(Configuration);
            User newUser = user;
            User dbUser = _context.User.FirstOrDefault(x => x.Email == newUser.Email);

            if(dbUser != null)
            {
                return BadRequest(new { error = $"A user with email: {newUser.Email} exists already"});
            }

            newUser.Password = userService.HashPassword(newUser, newUser.Password);
            newUser.Points = 0;

            _context.User.Add(newUser);

            await _context.SaveChangesAsync();

            return Ok( new { token = userService.CreateToken(newUser)});
        }
    }
}
