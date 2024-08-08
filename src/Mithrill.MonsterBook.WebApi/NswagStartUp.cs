using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mithrill.MonsterBook.WebApi.Common;

namespace Mithrill.MonsterBook.WebApi
{
    public class NSwagStartUp
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvcCore()
                .AddApiExplorer()
                .AddJsonOptions(option => option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddOpenApiServices(string.Empty);
        }

        public void Configure(IApplicationBuilder app, IHostEnvironment environment)
        {
            app.UseSwaggerMiddleware(environment, string.Empty);
        }
    }
}