﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SportsCampaign.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SportsCampaignDBEntities : DbContext
    {
        public SportsCampaignDBEntities()
            : base("name=SportsCampaignDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<RegisterTable> RegisterTables { get; set; }
        public virtual DbSet<contactTable> contactTables { get; set; }
        public virtual DbSet<CampaignTable> CampaignTables { get; set; }
        public virtual DbSet<catagoryTable> catagoryTables { get; set; }
        public virtual DbSet<CampaignBookedInfo> CampaignBookedInfoes { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }
    }
}
