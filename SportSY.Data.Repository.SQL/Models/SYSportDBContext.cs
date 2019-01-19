using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SportSY.Data.Repository.SQL.Models
{
    public partial class SYSportDBContext : DbContext
    {
        public SYSportDBContext()
        {
        }

        public SYSportDBContext(DbContextOptions<SYSportDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Activities> Activities { get; set; }
        public virtual DbSet<ActivityTypes> ActivityTypes { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }
        public virtual DbSet<Claims> Claims { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Persons> Persons { get; set; }
        public virtual DbSet<Places> Places { get; set; }
        public virtual DbSet<PlacesTypes> PlacesTypes { get; set; }
        public virtual DbSet<RequestStatusTypes> RequestStatusTypes { get; set; }
        public virtual DbSet<RequestsTypes> RequestsTypes { get; set; }
        public virtual DbSet<RoleClaims> RoleClaims { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Rquest> Rquest { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<UserLogins> UserLogins { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        // Unable to generate entity type for table 'dbo.TeamMembers'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RequestStatuses'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PlacesActivities'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TeamMatches'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.PersonsMatches'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=SYSportDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Activities>(entity =>
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

            modelBuilder.Entity<ActivityTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_UserRoles");

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.UserId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_UserRoles_Roles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Roles_Users_UserId");
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name })
                    .HasName("PK_UserTokens");
            });

            modelBuilder.Entity<Cities>(entity =>
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

            modelBuilder.Entity<Claims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Claims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_UserClaims_Users_UserId");
            });

            modelBuilder.Entity<Countries>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            modelBuilder.Entity<Persons>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DateOfBirth).HasMaxLength(50);

                entity.Property(e => e.EmailAddress).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Places>(entity =>
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

            modelBuilder.Entity<PlacesTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            modelBuilder.Entity<RequestStatusTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            modelBuilder.Entity<RequestsTypes>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            modelBuilder.Entity<RoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<Rquest>(entity =>
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

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.ArabicName).HasMaxLength(50);

                entity.Property(e => e.EnglishName).HasMaxLength(50);
            });

            modelBuilder.Entity<UserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey })
                    .HasName("PK_AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_AspNetUserLogins_AspNetUsers_UserId");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });
        }
    }
}
