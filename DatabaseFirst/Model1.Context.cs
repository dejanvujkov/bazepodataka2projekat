﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseFirst
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class e342_2014Entities : DbContext
    {
        public e342_2014Entities()
            : base("name=e342_2014Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<autobu> autobus { get; set; }
        public virtual DbSet<autobuska_stanica> autobuska_stanica { get; set; }
        public virtual DbSet<karta> kartas { get; set; }
        public virtual DbSet<mehanicar> mehanicars { get; set; }
        public virtual DbSet<poseduje> posedujes { get; set; }
        public virtual DbSet<prodavac> prodavacs { get; set; }
        public virtual DbSet<putnik> putniks { get; set; }
        public virtual DbSet<radnik> radniks { get; set; }
        public virtual DbSet<tip_karte> tip_karte { get; set; }
        public virtual DbSet<vozac> vozacs { get; set; }
        public virtual DbSet<vozna_linija> vozna_linija { get; set; }
    }
}
