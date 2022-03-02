using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebCv.Api.Data;
using WebCv.Api.Data.Services.Implementations;
using WebCv.Api.Data.Services.Interfaces;

namespace WebCv.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<WebCvContext>(
                opt => opt.UseNpgsql(
                    Configuration.GetConnectionString("webcv"),
                    npgsql => npgsql.MigrationsAssembly("WebCv.Api.Data"))
                .UseSnakeCaseNamingConvention());

            services
                .AddTransient<IKnowledgeDataService, KnowledgeDataService>()
                .AddTransient<IPersonalInformationDataService, PersonalInformationDataService>()
                .AddTransient<IProjectDataService, ProjectDataService>()
                .AddTransient<IResumeLineDataService, ResumeLineDataService>()
                .AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using var serviceScope = app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope();
            using var context = serviceScope.ServiceProvider.GetService<WebCvContext>();
            context.Database.Migrate();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
