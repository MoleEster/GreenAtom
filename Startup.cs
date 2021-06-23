using GreenAtom.Data.Database;
using GreenAtom.Data.Interfaces;
using GreenAtom.Data.Models;
using GreenAtom.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace GreenAtom
{
    public class Startup
    {
        public IConfigurationRoot _configurationString;
        public Startup(IWebHostEnvironment hostEnvironment)
        {
            _configurationString = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(_configurationString.GetConnectionString("DefaultConnection")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddTransient<IBaseInterface<Product>, ProductsRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseDeveloperExceptionPage();

            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=Products}/{action=Get}/{id?}");
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext content = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            }
        }
    }
}
