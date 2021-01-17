using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Thread> Threads { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PrivateMessage> PrivateMessages { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserSettings> UserSettings { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<PrivateMessage>(u => u.MessagesSent)
                .WithOne(pm => pm.Sender);

            modelBuilder.Entity<User>()
                .HasMany<PrivateMessage>(u => u.MessagesReceived)
                .WithOne(pm => pm.Recipient);

            modelBuilder.Entity<User>()
                .HasMany<Thread>(u => u.Threads)
                .WithOne(t => t.Creator);
        }
    }
}
