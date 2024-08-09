using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using RVASProject.Models;

namespace RVASProject.Data
{
    public class RentACarContext : IdentityDbContext<IdentityUser>
    {
        public RentACarContext() : base("DefaultConnection") { } 
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>()
                .HasKey(rc => new { rc.CarId, rc.CustomerId });

            modelBuilder.Entity<Rental>()
            .HasRequired(rc => rc.Car)
            .WithMany(r => r.Rentals)
            .HasForeignKey(rc => rc.CarId);

            modelBuilder.Entity<Rental>()
            .HasRequired(rc => rc.Customer)
            .WithMany(c => c.Rentals)
            .HasForeignKey(rc => rc.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
        public static RentACarContext Create()
        {
            return new RentACarContext();
        }

    }
}