using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExpensesTrackerApp.DataAccess.SqlServer;
using ExpensesTrackerApp.DataAccess;
using ExpensesTrackerApp.DataAccess.SqlServer.Repositories;
using ExpensesTrackerApp.DataAccess.Repositories;
using ExpensesTrackerApp.Core;
using ExpensesTrackerApp.Core.Account;
using ExpensesTrackerApp.Core.Identity;
using ExpensesTrackerApp.Core.Services;
using ExpensesTrackerApp.Core.Services.Identity;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Identity;

namespace ExpensesTrackerApp.Web
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
            services.AddLocalization(/*options => options.ResourcesPath = "Resources"*/);
            services.AddControllersWithViews();
            services.AddTransient<ExpensesTrackerAppContext>(_ =>
            {
                var config = _.GetService<IConfiguration>();
                var connString = config.GetConnectionString("ExpensesTrackerApp");
                return new ExpensesTrackerAppContext(connString);
            });
            services.AddTransient<IDataRepository, DataRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICustomersService, CustomersService>();

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);
            services.AddIdentity<User, Role>()
                .AddSignInManager()
                .AddDefaultTokenProviders();
            services.AddAuthentication()
                .AddCookie(opt =>
                {
                    opt.LoginPath = "Account/Login";
                    opt.LogoutPath = "Account/Logout";
                    opt.AccessDeniedPath = "Account/Denied";
                });
            /*
            services.AddTransient<IUserStore<User>, UserStore>();
            services.AddTransient<IUserPasswordStore<User>, UserStore>();
            services.AddTransient<IRoleStore<Role>, RoleStore>();
            */
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(null,"Account/Login",new { area="Account", controller="Authentication",action="Login"});
               endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
