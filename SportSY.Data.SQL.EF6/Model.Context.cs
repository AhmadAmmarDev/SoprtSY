﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportSY.Data.SQL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SYSportDBEntities : DbContext
    {
        public SYSportDBEntities()
            : base("name=SYSportDBEntities")
        {
        }

   
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
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
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<RequestStatuses> RequestStatuses { get; set; }
        public virtual DbSet<TeamMembers> TeamMembers { get; set; }
    }
}