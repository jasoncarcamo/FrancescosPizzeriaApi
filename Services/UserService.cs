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
using System.Text;
using FrancescosPizzeriaApi.Models;

namespace FrancescosPizzeriaApi.Services
{
    public class UserService
    {
        public IConfiguration Configuration { get; }
        public UserService( IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public string CreateToken(User user)
        {

            SymmetricSecurityKey secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetConnectionString("jwtSecret")));

            var hand = new JwtSecurityTokenHandler();

            var claimsIdentity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
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

        public string HashPassword(User user, string password)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            string hashedPassword = passwordHasher.HashPassword(user, password);

            return hashedPassword;
        }

        public bool ComparePassword( User user, string password, string hashedPassword)
        {
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

            PasswordVerificationResult matches = passwordHasher.VerifyHashedPassword(user, hashedPassword, password);

            if( matches == 0)
            {
                return false;
            }

            return true;
        }

    }
}
