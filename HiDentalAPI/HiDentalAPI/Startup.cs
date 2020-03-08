using BussinesLayer.Services.DataSeeds;
using DataBaseLayer.Settings;
using HiDentalAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace HiDentalAPI
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
            services.AddJwtConfiguration(Configuration);
            services.ImplementsCors();
            services.AddCustomIdentity();
            services.ConfigureDbContexts(Configuration);
            services.AddSettings(Configuration);
            services.ImplementServices();
            services.AddControllers();
            services.AddDocumentation();
            services.ConfigureAutoMapper();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<SwaggerSetting> options)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseAuthentication();
            app.UseCors(nameof(Startup));
            app.UseStaticFiles();
            app.UseSwagger(x => x.RouteTemplate = options.Value.RouteTemplate);
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(options.Value.Endpoint, options.Value.Name);
                x.RoutePrefix = options.Value.Route;
            });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            DataSeedService.SeedsOfApp(app);
        }
    }
}
