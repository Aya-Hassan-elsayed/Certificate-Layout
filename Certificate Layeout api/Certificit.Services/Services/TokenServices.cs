using Certificit.DAL.Entities.Identity;
using Certificit.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Certificit.Services.Services
{
    public class TokenServices : ITokenServices
    {
        public IConfiguration Configuration { get; }
        public TokenServices(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public async Task<string> GenerateToken(AppUser user, UserManager<AppUser> userManager)
        {
            //Private Claims (User - Definded)
            var authClaims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id ),
                new Claim(ClaimTypes.Email, user.Email ?? "" ),
                new Claim(ClaimTypes.GivenName, user.DisplayName ?? "" ),
                new Claim(ClaimTypes.MobilePhone, user.PhoneNumber ?? "" ),
                new Claim(ClaimTypes.Name, user.CompanyName ?? "" ),
                new Claim(ClaimTypes.Country, user.Country ?? "" ),
                new Claim(ClaimTypes.StateOrProvince, user.City ?? "" ),
                new Claim(ClaimTypes.StreetAddress, user.Street ?? "" )

            };
            var userRoles = await userManager.GetRolesAsync(user);

            foreach (var role in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, role));
            }

            //SecretKey
            await Console.Out.WriteLineAsync("!xC)*zWA)G9%{{a~+UiKtQwG9}lEkS");
            var autKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"] ?? "!xC)*zWA)G9%{{a~+UiKtQwG9}lEkS"));

            var Token = new JwtSecurityToken(
                issuer: Configuration["Jwt:ValiedIssuer"],
                audience: Configuration["Jwt:ValiedAudience"],
                expires: DateTime.Now.AddDays(double.Parse(Configuration["Jwt:DurationInDays"] ?? "30")),
                claims : authClaims,
                signingCredentials : new SigningCredentials(autKey , SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(Token);
        }
    }
}
