using System;
using Microsoft.EntityFrameworkCore;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasData(new Role()
                {
                    Id = 1, Name = "Admin",
                });

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = 1, UserName = "Florian", Signature = "Cool Signature", PostCount = 0,
                    LastSeen = DateTime.Now, JoinedAt = DateTime.Now
                });

        }
    }
}