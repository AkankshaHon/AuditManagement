using AuditManagementPortalClientMVC.Models.Context;
using AuditManagementPortalClientMVC.Providers;
using AuditManagementPortalClientMVC.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuditManagementPortalClientMVC
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
            services.AddDbContext<AuditDbContext>(item => item.UseSqlServer(Configuration.GetConnectionString("conn")));
            services.AddControllersWithViews();
            services.AddMemoryCache();
            services.AddSession();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IChecklistProvider, ChecklistProvider>();
            services.AddScoped<IChecklistRepo, ChecklistRepo>();
            services.AddScoped<ILoginProvider, LoginProvider>();
            services.AddScoped<ILoginRepo, LoginRepo>();
            services.AddScoped<ISeverityProvider, SeverityProvider>();
            services.AddScoped<ISeverityRepo, SeverityRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();
            app.UseCookiePolicy();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Login}/{id?}");
            });
        }
    }
}
