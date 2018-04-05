using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Streamliner.Models;
using Streamliner.Repositories;

namespace Streamliner
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:Streamliner:ConnectionString"]));
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IKiddoRepository, KiddoRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes => {
            //});
            SeedData.EnsurePopulated(app);
        }
    }
}

//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using Streamliner.Models;
//using Streamliner.Repositories;

//namespace Streamliner
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//            => Configuration = configuration;
//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.AddMvc();
//                services.AddDbContext<ApplicationDbContext>(
//                    options => options.UseSqlServer(
//                        Configuration["Data:Streamliner:ConnectionString"]));


//            services.AddTransient<IKiddoRepository, KiddoRepository>();
//            services.AddTransient<ITaskRepository, TaskRepository>();

//            services.AddIdentity<User, IdentityRole>(opts =>
//            {
//                opts.User.RequireUniqueEmail = false;
//                opts.Password.RequiredLength = 6;
//                opts.Password.RequireNonAlphanumeric = false;
//                opts.Password.RequireLowercase = false;
//                opts.Password.RequireUppercase = false;
//                opts.Password.RequireDigit = false;
//            }).AddEntityFrameworkStores<ApplicationDbContext>()
//              .AddDefaultTokenProviders();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
//        {
//            loggerFactory.AddConsole();

//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//            }
//            app.UseAuthentication();   // Must precede app.UseMvc!!!
//            app.UseMvcWithDefaultRoute();
//            app.UseStaticFiles();
//            SeedData.EnsurePopulated(app);
//            //ApplicationDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();
//        }
//    }
//}
