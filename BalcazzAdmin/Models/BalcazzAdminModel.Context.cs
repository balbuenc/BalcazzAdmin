﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BalcazzAdmin.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BalcazzEntities : DbContext
    {
        public BalcazzEntities()
            : base("name=BalcazzEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Conceptos> Conceptos { get; set; }
        public virtual DbSet<Facturas> Facturas { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}