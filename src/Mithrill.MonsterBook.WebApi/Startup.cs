using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mithrill.MonsterBook.Application;
using Mithrill.MonsterBook.Infrastructure;
using Mithrill.MonsterBook.WebApi.Controllers.Common;
using NSwag;

namespace Mithrill.MonsterBook.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(mvcOptions => mvcOptions.Conventions.Add(new NotFoundResultFilterConvention()));
            services.RegisterApplication();
            services.RegisterRepository(Configuration);
            services.AddOpenApiDocument(configure =>
            {
                configure.Title = "Mithrill MonsterBook API";
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi(settings =>
            {
                settings.PostProcess = (document, request) =>
                {
                    if (env.IsDevelopment() || document.Schemes.Any(schema => schema == OpenApiSchema.Https))
                        return;

                    document.Schemes.Add(OpenApiSchema.Https);
                    document.Schemes.Remove(OpenApiSchema.Http);
                };
            });

            app.UseSwaggerUi3(settings =>
            {
                settings.Path = "/api";
            });
        }
    }
}