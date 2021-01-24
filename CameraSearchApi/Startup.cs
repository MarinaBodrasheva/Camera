using CameraSearchService.Repo;
using CameraSearchService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CameraSearchApi
{
    public class Startup
    {
        readonly string SpaOrigins = "_spaOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddMemoryCache();
            services.AddScoped<ICameraService, CameraService>();
            services.AddScoped<ICameraDataRepository, CameraDataCsvRepository>();

            services.AddCors(options =>
            {
                options.AddPolicy(name: SpaOrigins,
                    builder =>
                    {
                        //TODO: Move to configuration
                        builder.WithOrigins("http://localhost:4200");
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMemoryCache cache, ICameraService cameraService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(SpaOrigins);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //TODO: Add cache update background job
            var cameraData = cameraService.GetData();
            cache.Set("camera", cameraData);
        }
    }
}
