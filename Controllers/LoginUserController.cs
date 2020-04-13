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
    public class LoginUserController : ControllerBase
    {
        private readonly FrancescosPizzeriaContext _context;

        public IConfiguration Configuration { get; }

        public LoginUserController(FrancescosPizzeriaContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

      
        // POST: api/LoginUser
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            UserService userService = new UserService(Configuration);

            User currentUser = user;
            User dbUser = _context.User.FirstOrDefault(x => x.Email == currentUser.Email);

            if(dbUser == null)
            {
                return NotFound(new { error = "User was not found with this email" });
            }

            bool passwordMatches = userService.ComparePassword(dbUser, currentUser.Password, dbUser.Password);

            if (!passwordMatches)
            {
                return BadRequest( new { error = "Wrong password" });
            }

            return Ok( new { token = userService.CreateToken(dbUser)});
        }

    }
}
