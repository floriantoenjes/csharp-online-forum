using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnlineForum.Data;
using OnlineForum.Models;

namespace OnlineForum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void SeedDatabase(Context context)
        {
            var adminRole = new Role();
            adminRole.Name = "Admin";
            context.Roles.Add(adminRole);
            
            var florian = new User();
            florian.UserName = "Florian";
            florian.Signature = "Cool Signature";
            florian.PostCount = 0;
            florian.Reputation = 0;
            florian.LastSeen = DateTime.Now;
            florian.JoinedAt = DateTime.Now;
            florian.UserRole = adminRole;
            context.Users.Add(florian);

            context.SaveChanges();

        }
    }
}
