﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TemaProje_6_
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AvmEntities : DbContext
    {
        public AvmEntities()
            : base("name=AvmEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Ayakkabi> Ayakkabi { get; set; }
        public virtual DbSet<Canta> Canta { get; set; }
        public virtual DbSet<EvYasam> EvYasam { get; set; }
        public virtual DbSet<Kiyafet> Kiyafet { get; set; }
        public virtual DbSet<Sube> Sube { get; set; }
    }
}
