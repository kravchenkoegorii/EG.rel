using Eg.rel.AuthService.Data;
using Eg.rel.AuthService.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Eg.rel.AuthService
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
            services.AddDbContext<UserContext>(options => options
           .UseLazyLoadingProxies()
           .EnableSensitiveDataLogging()
           .UseNpgsql(Configuration.GetConnectionString("AuthServiceDb"), o =>
           {
               o.UseNetTopologySuite();
           })
           .UseSnakeCaseNamingConvention());

            services.AddIdentityServices(Configuration);
            services.AddApplicationServices();

            services.AddSwaggerGen();
            services.AddControllers();
            services.AddCors();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/swagger/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "EG.rel.WebApi v1");
            }
            );
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}
