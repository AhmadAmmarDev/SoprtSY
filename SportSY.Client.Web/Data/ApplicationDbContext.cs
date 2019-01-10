using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportSY.Client.Web.Models;

namespace SportSY.Client.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,Role,Guid,Claim,UserRole,UserLogin,RoleClaim,UserToken>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "Users");
                //entity.Property(e => e.Id).HasColumnName("UserId");

            });
            builder.Entity<Claim>(entity =>
            {
                entity.ToTable(name: "Claims");
                //entity.Property(e => e.Id).HasColumnName("UserId");

            });
            builder.Entity<Role>(entity =>
            {
                entity.ToTable(name: "Roles");
                //entity.Property(e => e.Id).HasColumnName("UserId");

            });
            builder.Entity<UserRole>(entity =>
            {
                entity.ToTable(name: "UserRoles");
                //entity.Property(e => e.Id).HasColumnName("UserId");

            });
            builder.Entity<UserLogin>(entity =>
            {
                entity.ToTable(name: "UserLogins");
                //entity.Property(e => e.Id).HasColumnName("UserId");

            });
            builder.Entity<RoleClaim>(entity =>
            {
                entity.ToTable(name: "RoleClaims");
                //entity.Property(e => e.Id).HasColumnName("UserId");

            });
            builder.Entity<UserToken>(entity =>
            {
                entity.ToTable(name: "UserTokens");
                //entity.Property(e => e.Id).HasColumnName("UserId");

            });
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
