using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using gp_.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using gp_.Services;
using gp_.Extentions;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace gp_
{
    public class Startup
    {
        //yousef
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            // services.AddIdentity
            // requires
            // using Microsoft.AspNetCore.Identity.UI.Services;
            // using WebPWrecover.Services;
            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddControllersWithViews();
            services.AddAuthorization();
            services.AddMvc();
            services.AddSingleton<IUserService, UserService>();
            services.AddDirectoryBrowser();
            services.AddAuthentication();
            services.AddRouting();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
               //   app.UseExceptionHandler("/Shared/Error");
               app.UseStatusCodePagesWithRedirects("/error/{0}");

                app.UseDatabaseErrorPage();
            }
            else
            {
                //140
               // app.UseExceptionHandler("/Shared/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
           // endpoints.MapAreaControllerRoute(null, "MvcDashboardIdentity", "MvcDashboardIdentity/{controller=Home}/{action=Index}/{id?}");

            app.UseHttpsRedirection();
            app.UseStaticFiles();
 app.UseWebSockets();
            app.UseCommunicationMiddleware();

            app.UseRouting();

            app.UseFileServer();

            app.UseAuthentication();
            app.UseAuthorization();

            //    app.UseDirectoryBrowser();
             app.UseMvcWithDefaultRoute();
            //app.
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(null, "MvcDashboardIdentity", "MvcDashboardIdentity/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // refur to page 136 when needed 
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
       //private static void Apip
    }
}
