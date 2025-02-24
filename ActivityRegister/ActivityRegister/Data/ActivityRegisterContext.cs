using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActivityRegister.Models;

namespace ActivityRegister.Data
{
    public class ActivityRegisterContext : DbContext
    {
        public ActivityRegisterContext (DbContextOptions<ActivityRegisterContext> options)
            : base(options)
        {
        }

        public DbSet<ActivityRegister.Models.Registration> Registration { get; set; } = default!;
        public DbSet<ActivityRegister.Models.Activity> Activity {  get; set; } = default!;
        public DbSet<ActivityRegister.Models.User> User { get; set; } = default!;
        public DbSet<ActivityRegister.Models.Waitlist> Waitlist { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Registration Configuration
            modelBuilder.Entity<Registration>(b =>
            {
                b.HasKey(r => r.Id);
                b.HasOne(r => r.Activity)
                    .WithMany(a => a.Registrations)
                    .HasForeignKey(r => r.ActivityId)
                    .OnDelete(DeleteBehavior.Restrict); // Already defined in Activity config, but good to have here too
                b.HasOne(r => r.User)
                    .WithMany(u => u.Registrations)
                    .HasForeignKey(r => r.UserId)
                    .OnDelete(DeleteBehavior.Cascade); // If User is deleted, Registration is deleted
            });

            // Activity Configuration
            modelBuilder.Entity<Activity>(b =>
            {
                b.HasKey(a => a.Id); 
                b.Property(a => a.ActivityName).IsRequired(); 
                b.HasMany(a => a.Registrations)
                    .WithOne(r => r.Activity)
                    .HasForeignKey(r => r.ActivityId)
                    .OnDelete(DeleteBehavior.Restrict); // Prevent deleting Activity if Registrations exist
                b.HasMany(a => a.Waitlists)
                    .WithOne(w => w.Activity)
                    .HasForeignKey(w => w.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade); // Delete Waitlist entries if Activity is deleted
            });

            // User Configuration
            modelBuilder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);
                //b.Property(u => u.Email).IsRequired();
                b.HasMany(u => u.Registrations) // User has many Registrations
                 .WithOne(r => r.User)       // One Registration belongs to one User
                 .HasForeignKey(r => r.UserId) // Foreign key in Registration table
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // Waitlist Configuration
            modelBuilder.Entity<Waitlist>(b =>
            {
                b.HasKey(w => w.Id);
                b.HasOne(w => w.Activity)
                    .WithMany(a => a.Waitlists)
                    .HasForeignKey(w => w.ActivityId)
                    .OnDelete(DeleteBehavior.Cascade);
                b.HasOne(w => w.User)
                    .WithMany(u => u.Waitlists)
                    .HasForeignKey(w => w.UserId)
                    .OnDelete(DeleteBehavior.NoAction); // Don't delete User if Waitlist entry is deleted
            });

        }

    }
}
