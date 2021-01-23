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
            modelBuilder.Entity<PrivateMessage>()
                .HasOne<User>(pm => pm.Sender)
                .WithMany(u => u.MessagesSent)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PrivateMessage>()
                .HasOne<User>(pm => pm.Recipient)
                .WithMany(u => u.MessagesReceived)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<User>()
                .HasMany<Thread>(u => u.Threads)
                .WithOne(t => t.Creator)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Thread>()
                .HasOne<Board>(t => t.LastThreadOn)
                .WithOne(b => b.LastThread)
                .HasForeignKey<Board>("LastThreadId");
            
            modelBuilder.Seed();
        }
    }
}
