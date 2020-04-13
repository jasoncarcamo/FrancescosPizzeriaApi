using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using FrancescosPizzeriaApi.Models;

namespace FrancescosPizzeriaApi.Services
{
    public class EmployeeService
    {
        public EmployeeService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public string createToken(Employee employee)
        {
            SymmetricSecurityKey secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetConnectionString("jwtSecret")));

            var hand = new JwtSecurityTokenHandler();

            var claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, employee.Id.ToString()),
                    new Claim("authorize", "true")
                });

            var securityTokenDescriptor = new SecurityTokenDescriptor()
            {
                Issuer = "https://localhost:5001/",
                Audience = "https://localhost:5001/",
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddYears(12),
                SigningCredentials = new SigningCredentials(secret, SecurityAlgorithms.HmacSha256Signature, SecurityAlgorithms.Sha512Digest)
            };

            var plainToken = hand.CreateToken(securityTokenDescriptor);
            var token = hand.WriteToken(plainToken);

            return token;
        }

        public string HashPin(Employee employee, string pin)
        {
            PasswordHasher<Employee> pinHasher = new PasswordHasher<Employee>();

            string hashedPin = pinHasher.HashPassword(employee, pin);

            return hashedPin;
        }

        public bool ComparePin(Employee employee, string pin, string hashedPin)
        {
            PasswordHasher<Employee> pinHasher = new PasswordHasher<Employee>();

            PasswordVerificationResult matches = pinHasher.VerifyHashedPassword(employee, hashedPin, pin);

            if(matches == 0)
            {
                return false;
            }

            return true;
        }
    }
}
