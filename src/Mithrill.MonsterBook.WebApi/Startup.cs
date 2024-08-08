using System.Text.Json.Serialization;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Mithrill.MonsterBook.Application;
using Mithrill.MonsterBook.Infrastructure;
using Mithrill.MonsterBook.WebApi.Common;
using Newtonsoft.Json.Converters;

namespace Mithrill.MonsterBook.WebApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostEnvironment _environment;

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            _configuration = configuration;
            _environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(mvcOptions => mvcOptions.Conventions.Add(new NotFoundResultFilterConvention()))
                .AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.RegisterApplication();
            services.RegisterRepository(_configuration);
            services.AddSpaStaticFiles(configuration => configuration.RootPath = "offers-engine/dist/offers-engine");
            services.AddHttpContextAccessor();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers(options => options.Filters.Add<ExpectedExceptionFilter>())
                .AddNewtonsoftJson(option => option.SerializerSettings.Converters.Add(new StringEnumConverter()));
            services.AddOpenApiServices("Mithrill MonsterBook API");

            var mapperConfiguration = new MapperConfiguration(configure => configure.AddMaps(typeof(Application.Common.Mappings.MappingProfile).Assembly));
            mapperConfiguration.AssertConfigurationIsValid();

            if (_environment.IsDevelopment())
            {
                services.AddCors(options => options.AddDefaultPolicy(policy =>
                    policy.AllowAnyHeader()
                        .AllowAnyMethod()
                        .WithOrigins("http://localhost:4200", "https://localhost:4200")));
            }
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            if (_environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerMiddleware(_environment, string.Empty);
                app.UseCors();
            }
            else
            {
                app.UseSpaStaticFiles();
            }

            app.UseStaticFiles();
            app.UseHsts();
            app.UseHttpsRedirection();
            app.UseSpaStaticFiles();
            app.UseExceptionHandler(options => options.UseApiExceptionHandler(_environment, loggerFactory));
            app.UseRouting();
            app.UseEndpoints(e => e.MapDefaultControllerRoute());

            app.Map("/api", preserveMatchedPathSegment: true, api =>
            {
                api.UseRouting();
                api.UseEndpoints(endpoints =>
                {
                    endpoints.MapDefaultControllerRoute();
                });
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "monsterbook";
                if (_environment.IsDevelopment())
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
            });
        }
    }
}