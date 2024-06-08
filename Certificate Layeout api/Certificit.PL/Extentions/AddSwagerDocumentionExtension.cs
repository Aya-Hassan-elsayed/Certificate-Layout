using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Certificit.PL.Extentions
{
    public static class AddSwagerDocumentionExtension
    {
        public static IServiceCollection AddSwagerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
                   {
                            c.SwaggerDoc("v1", new OpenApiInfo { Title = "SPP.PL", Version = "v1" });
                   });
            return services;
        }
        public static IApplicationBuilder SwagerDoc(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SPP.PL v1"));
            return app;
        }
    }
}
