using BEE;
using DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace pr
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
            services.AddMvc();
            services.AddDbContext<db>(s => s.UseSqlServer(Configuration.GetConnectionString("Con1")));
            //services.AddTransient<uploadfile>();
           
            services.AddIdentity<User, IdentityRole>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequireUppercase = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequiredLength = 4;
                option.SignIn.RequireConfirmedPhoneNumber = false;
            }).AddUserManager<UserManager<User>>().AddRoles<IdentityRole>().AddRoleManager<RoleManager<IdentityRole>>().AddEntityFrameworkStores<db>();
            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromDays(2);
            });
             services.ConfigureApplicationCookie(option => {
                option.AccessDeniedPath = "/Account/Accessdinid";
                option.Cookie.Name = "WebAppIdentityCooki";
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = TimeSpan.FromSeconds(30);
                option.LoginPath = "/Account/login";
                option.SlidingExpiration = true;
            });
             services.AddControllersWithViews().AddRazorRuntimeCompilation();

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
