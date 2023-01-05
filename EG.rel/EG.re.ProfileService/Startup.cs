using EG.rel.ProfileService.Data;
using EG.rel.ProfileService.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EG.re.ProfileService
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
            services.AddDbContext<ProfileDbContext>(options => options
           .UseLazyLoadingProxies()
           .EnableSensitiveDataLogging()
           .UseNpgsql(Configuration.GetSection("Config:ConnectionString").Value)
           .UseSnakeCaseNamingConvention());

            services.AddScoped<IProfileService, rel.ProfileService.Services.ProfileService>();
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

