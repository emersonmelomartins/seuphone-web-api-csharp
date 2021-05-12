using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Seuphone.Api.Models;

namespace Seuphone.Api.Data
{
    public class SeuphoneApiContext : DbContext
    {
        public SeuphoneApiContext(DbContextOptions<SeuphoneApiContext> options)
            : base(options)
        {
        }

        public DbSet<Seuphone.Api.Models.User> User { get; set; }

        public DbSet<Seuphone.Api.Models.Role> Role { get; set; }

        public DbSet<Seuphone.Api.Models.UserRole> UserRole { get; set; }

        public DbSet<Seuphone.Api.Models.Provider> Provider { get; set; }

        public DbSet<Seuphone.Api.Models.Product> Product { get; set; }

        public DbSet<Seuphone.Api.Models.Order> Order { get; set; }

        public DbSet<Seuphone.Api.Models.OrderItems> OrderItems { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });

            //modelBuilder.Entity<UserRole>()
            //    .HasOne<User>(ur => ur.User)
            //    .WithMany(u => u.UserRoles)
            //    .HasForeignKey(ur => ur.UserId);


            //modelBuilder.Entity<UserRole>()
            //    .HasOne<Role>(ur => ur.Role)
            //    .WithMany(r => r.UserRoles)
            //    .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.CPF)
                .IsUnique();
        }
    }
}
