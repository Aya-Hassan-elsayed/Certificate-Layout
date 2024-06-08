using Certificit.BLL.Identity;
using Certificit.DAL.Entities.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Certificit.PL.Extentions
{
    public static class IdentityServicExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                // Your Identity options configuration
            })
            .AddEntityFrameworkStores<AppIdentityDBContext>()
            .AddDefaultTokenProviders(); // Add this line to include default token providers

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:ValiedIssuer"] ?? "https://localhost:5001",
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:ValiedAudience"] ?? "MySecuredApiUsers",
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? "!xC)*zWA)G9%{{a~+UiKtQwG9}lEkS"))
                };
            });
            return services;
        }
    }
}
