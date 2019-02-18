using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SportSY.Data.Repository.SQL.Models;

namespace SportSY.Client.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Activities>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.HasOne(d => d.ActivityTypeNavigation)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.ActivityType)
                    .HasConstraintName("FK_Activities_ActivityTypes_ActivityTypeID");
            });

            builder.Entity<ActivityTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            builder.Entity<Cities>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            builder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            builder.Entity<Persons>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            builder.Entity<Places>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.EnglishName).HasMaxLength(50);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Places)
                    .HasForeignKey(d => d.CityId);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Places)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Places_PlacesTypes_PlaceTypeID");
            });

            builder.Entity<PlacesTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            builder.Entity<RequestStatusTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            builder.Entity<RequestsTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            builder.Entity<Rquest>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ActivityId).HasColumnName("ActivityID");

                entity.Property(e => e.FromPersonId).HasColumnName("FromPersonID");

                entity.Property(e => e.MatchDate).HasColumnType("datetime");

                entity.Property(e => e.PlaceId).HasColumnName("PlaceID");

                entity.Property(e => e.RequestTypeId).HasColumnName("RequestTypeID");

                entity.Property(e => e.ToPersonId).HasColumnName("ToPersonID");

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Rquest)
                    .HasForeignKey(d => d.ActivityId);

                entity.HasOne(d => d.FromTeamNavigation)
                    .WithMany(p => p.RquestFromTeamNavigation)
                    .HasForeignKey(d => d.FromTeam)
                    .HasConstraintName("FK_Rquest_Teams_FromTeamID");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Rquest)
                    .HasForeignKey(d => d.PlaceId);

                entity.HasOne(d => d.RequestType)
                    .WithMany(p => p.Rquest)
                    .HasForeignKey(d => d.RequestTypeId);

                entity.HasOne(d => d.ToTeamNavigation)
                    .WithMany(p => p.RquestToTeamNavigation)
                    .HasForeignKey(d => d.ToTeam)
                    .HasConstraintName("FK_Rquest_Teams_ToTeamID");
            });

            builder.Entity<Teams>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            builder.Entity<TeamMembers>().HasKey(k => new { k.PersonID, k.TeamID });
            builder.Entity<TeamMembers>()
                .HasOne<Teams>(sc => sc.Team)
                .WithMany(s => s.TeamMembers)
                .HasForeignKey(sc => sc.TeamID);


            builder.Entity<TeamMembers>()
                .HasOne<Persons>(sc => sc.Person)
                .WithMany(s => s.TeamMembers)
                .HasForeignKey(sc => sc.PersonID);
        }

        public virtual DbSet<Activities> Activities { get; set; }
        public virtual DbSet<ActivityTypes> ActivityTypes { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<PlacesTypes> PlacesTypes { get; set; }
        public virtual DbSet<RequestStatusTypes> RequestStatusTypes { get; set; }
        public virtual DbSet<RequestsTypes> RequestsTypes { get; set; }
        public virtual DbSet<Rquest> Rquest { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<TeamMembers> TeamMembers { get; set; }
    }
}