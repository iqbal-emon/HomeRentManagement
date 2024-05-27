using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Collections.Generic;

namespace HomeRentManagement.Data
{
    public class addDbContex : DbContext
    {
        private readonly IConfiguration _configuration;

        public addDbContex(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _configuration.GetConnectionString("DbConnectionString");

            optionsBuilder.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5, // Maximum number of retries
                    maxRetryDelay: TimeSpan.FromSeconds(30), // Maximum delay between retries
                    errorNumbersToAdd: null); // SQL error numbers to retry on
            })
            .ConfigureWarnings(warnings => warnings.Throw()); // Optional: Configure warnings
        }


        public DbSet<User> Users { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Floor> Floors { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuss { get; set; }
        public DbSet<BillGenerate>BillGenerates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasOne(r => r.statuss)
                .WithMany()
                .HasForeignKey(r => r.StatusId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete behavior

            modelBuilder.Entity<User>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleID)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete behavior for roles

            modelBuilder.Entity<House>()
                .HasOne(h => h.Status)
                .WithMany()
                .HasForeignKey(h => h.StatusId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete behavior

            modelBuilder.Entity<Unit>()
                .HasOne(u => u.Status)
                .WithMany()
                .HasForeignKey(u => u.StatusId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete behavior

            modelBuilder.Entity<Unit>()
             .HasOne(u => u.House)
             .WithMany()
             .HasForeignKey(u => u.HomeId)
             .OnDelete(DeleteBehavior.Restrict); // Restrict delete behavior

            modelBuilder.Entity<Unit>()
                .HasOne(u => u.Owner)
                .WithMany()
                .HasForeignKey(u => u.OwnerId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete behavior
            modelBuilder.Entity<Tenant>()
            .HasOne(u => u.Status)
            .WithMany()
            .HasForeignKey(u => u.StatusId)
            .OnDelete(DeleteBehavior.Restrict); // Restrict delete behavior

            modelBuilder.Entity<Tenant>()
                .HasOne(u => u.Owner)
                .WithMany()
                .HasForeignKey(u => u.OwnerId)
                .OnDelete(DeleteBehavior.Restrict); // Restrict delete behavior
            modelBuilder.Entity<Tenant>()
              .HasOne(u => u.House)
              .WithMany()
              .HasForeignKey(u => u.HomeId)
              .OnDelete(DeleteBehavior.Restrict); // Restrict delete behavior
            modelBuilder.Entity<Payment>()
               .HasOne(u => u.Unit)
               .WithMany()
               .HasForeignKey(u => u.UnitID)
               .OnDelete(DeleteBehavior.Restrict); // Restrict delete behavior
            modelBuilder.Entity<Payment>()
               .HasOne(u => u.Tenant)
               .WithMany()
               .HasForeignKey(u => u.TenantID)
               .OnDelete(DeleteBehavior.Restrict); // Restrict delete behavior
            
        }

    }
}
