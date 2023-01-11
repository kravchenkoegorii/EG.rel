using Eg.rel.AuthService.Data;
using Eg.rel.AuthService.Services;
using Eg.rel.AuthService.Services.Extensions;
using Microsoft.EntityFrameworkCore;

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
            var a = Configuration.GetSection("Config:ConnectionString").Value;
            services.AddDbContext<UserContext>(options => options
           .UseLazyLoadingProxies()
           .EnableSensitiveDataLogging()
           .UseNpgsql(Configuration.GetSection("Config:ConnectionString").Value, o =>
           {

           })
           .UseSnakeCaseNamingConvention());

            services.AddIdentityServices(Configuration);
            services.AddApplicationServices();

            services.AddSwaggerGen();
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("CORS", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
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
            app.UseCors("CORS");

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
