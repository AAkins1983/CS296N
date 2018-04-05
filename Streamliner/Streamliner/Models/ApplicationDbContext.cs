using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Streamliner.Models
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
        public DbSet<Kiddo> Kiddos { get; set; }
    }

    public class ApplicationDbContextFactory
        : IDesignTimeDbContextFactory<ApplicationDbContext>
    {

        public ApplicationDbContext CreateDbContext(string[] args) =>
            Program.BuildWebHost(args).Services
                .GetRequiredService<ApplicationDbContext>();

        //public static async Task CreateAdminAccount(IServiceProvider serviceProvider, IConfiguration configuration)
        //{
        //    UserManager<User> userManager =
        //        serviceProvider.GetRequiredService<UserManager<User>>();
        //    RoleManager<IdentityRole> roleManager =
        //        serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    string username = configuration["Data:AdminUser:Name"];
        //    //string email = configuration["Data:AdminUser:Email"];
        //    string password = configuration["Data:AdminUser:Password"];
        //    string role = configuration["Data:AdminUser:Role"];
        //    if (await userManager.FindByNameAsync(username) == null)
        //    {
        //        if (await roleManager.FindByNameAsync(role) == null)
        //        {
        //            await roleManager.CreateAsync(new IdentityRole(role));
        //        }
        //        User user = new User
        //        {
        //            UserName = username,
        //            //Email = email
        //        };
        //        IdentityResult result = await userManager
        //        .CreateAsync(user, password);
        //        if (result.Succeeded)
        //        {
        //            await userManager.AddToRoleAsync(user, role);
        //        }
        //    }
        //}
    }
}