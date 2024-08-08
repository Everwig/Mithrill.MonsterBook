using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;

namespace Mithrill.MonsterBook.WebApi.Common
{
    public static class OpenApiExtensions
    {
        public static void AddOpenApiServices(this IServiceCollection services, string title)
        {
            services.AddOpenApiDocument(configure =>
            {
                configure.Title = title;
                configure.DocumentProcessors.Add(new ResponseTypeJsonSchemaProcessor());
            });
        }

        public static void UseSwaggerMiddleware(this IApplicationBuilder app, IHostEnvironment environment, string title)
        {
            app.UseOpenApi(settings =>
            {
                settings.PostProcess = (document, request) =>
                {
                    if (!environment.IsDevelopment() && document.Schemes.All(schema => schema != OpenApiSchema.Https))
                    {
                        document.Schemes.Add(OpenApiSchema.Https);
                        document.Schemes.Remove(OpenApiSchema.Http);
                    }
                };
            });

            app.UseSwaggerUi(settings =>
            {
                settings.Path = "/api";
            });
        }
    }
}