﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PrintManagementSystemEntities : DbContext
    {
        public PrintManagementSystemEntities()
            : base("name=PrintManagementSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<ConfigurationType> ConfigurationTypes { get; set; }
        public virtual DbSet<ItemDisplayConfig> ItemDisplayConfigs { get; set; }
        public virtual DbSet<JobProcessType> JobProcessTypes { get; set; }
        public virtual DbSet<OrderConfiguration> OrderConfigurations { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<PaperGSM> PaperGSMs { get; set; }
        public virtual DbSet<PaperQuality> PaperQualities { get; set; }
        public virtual DbSet<PaperSide> PaperSides { get; set; }
        public virtual DbSet<PrintingColour> PrintingColours { get; set; }
        public virtual DbSet<ProductItem> ProductItems { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserSecurityQuestion> UserSecurityQuestions { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<LedgerFalio> LedgerFalios { get; set; }
        public virtual DbSet<PaperSize> PaperSizes { get; set; }
    }
}
