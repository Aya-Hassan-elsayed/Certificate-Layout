using Certificit.BLL.Identity;
using Certificit.BLL.Interfaces;
using Certificit.BLL.Repositories;
using Certificit.BLL.Repostiories;
using Certificit.DAL.Entities;
using Certificit.DAL.Interfaces;
using Certificit.PL.Error;
using Certificit.PL.Helper;
using Certificit.Services.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using System;
using System.Linq;

namespace Certificit.PL.Extentions
{
    public static class AddCustomServiceExtenision
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenaricInterface<>), typeof(GenaricRepository<>));
            services.AddScoped(typeof(ICertificateLayout), typeof(CertificateLayoutRepository));
            services.AddScoped(typeof(IEditeCertificateLayout), typeof(EditCertificateViewLayoutRepository));
            services.AddScoped(typeof(IUniteType), typeof(UniteTypeRepository));
            services.AddScoped(typeof(ITokenServices), typeof(TokenServices));
            services.AddAutoMapper(typeof(MappingProfile));

            var DefaultDb = configuration.GetConnectionString("DefaultDb");
            Console.WriteLine(DefaultDb);
            services.AddDbContext<RSCContext>(options =>
            {
                options.UseNpgsql(DefaultDb);
            });
            var IdentityDB = configuration.GetConnectionString("IdentityDB");

            services.AddDbContext<AppIdentityDBContext>(options =>
            {
                options.UseNpgsql(IdentityDB, x => x.UseNetTopologySuite());
            });


            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = (ContextAction) =>
                {
                    var ValidationApiErrors = ContextAction.ModelState.Where(E => E.Value.Errors.Count() > 0) // Check Is Found Error
                                                          .SelectMany(E => E.Value.Errors) // Return Error As Array Object
                                                          .Select(E => E.ErrorMessage) // Select ErrorMessage From Object
                                                          .ToArray();

                    ValidationErrorResponse validationErrorResponse = new ValidationErrorResponse()
                    {
                        Errors = ValidationApiErrors.ToList()
                    };
                    return new BadRequestObjectResult(validationErrorResponse);

                };
            });
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins( "http://10.100.102.88:4200", "http://localhost:4200")
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                });
            });

            return services; // Becues if i want  not this Write Service . --- i can write service.-----.----.-----  
        }
    }
}
