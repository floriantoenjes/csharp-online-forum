using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineForum.Models;

namespace OnlineForum.Data
{
    public sealed class Context : IdentityDbContext<User, Role, int>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            ChangeTracker.StateChanged += SetCreatedAt;
            ChangeTracker.Tracked += SetCreatedAt;
            
        }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Thread> Threads { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PrivateMessage> PrivateMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

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

        private static void SetCreatedAt(object sender, EntityEntryEventArgs e)
        {
            if (e.Entry.Entity is IHasCreatedAt entityWithCreatedAt)
            {
                switch (e.Entry.State)
                {
                    case EntityState.Added:
                        entityWithCreatedAt.CreatedAt = DateTime.Now;
                        break;
                }
            }
        }
    }
}
