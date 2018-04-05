using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MagicPonySparkleLand.Models;
using MagicPonySparkleLand.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;

namespace MagicPonySparkleLand
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                services.AddDbContext<ApplicationDbContext>(
                    options => options.UseSqlServer(
                        Configuration["Data:MagicPonySparkleLand:ConnectionString"]));
            }
            //else
            //{
            //    services.AddDbContext<ApplicationDbContext>(
            //       options => options.UseSqlite(
            //           Configuration["Data:MagicPonySparkleLand:SQLiteConnectionString"]));
            //}

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();

            services.AddIdentity<NewUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvcWithDefaultRoute();
            app.UseAuthentication();
            app.UseStaticFiles();
        }

        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    app.UseDeveloperExceptionPage();
        //    app.UseStatusCodePages();
        //    app.UseStaticFiles();
        //    app.UseMvcWithDefaultRoute();
        //    //app.UseMvc(routes => {
        //    //});
        //    //SeedData.EnsurePopulated(app);
        //}
    }
}
