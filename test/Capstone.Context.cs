﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace test
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class capstoneEntities : DbContext
    {
        public capstoneEntities()
            : base("name=capstoneEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<TAbdomenInfo> TAbdomenInfos { get; set; }
        public DbSet<TBreed> TBreeds { get; set; }
        public DbSet<TEarStatusInfo> TEarStatusInfos { get; set; }
        public DbSet<TEmployee> TEmployees { get; set; }
        public DbSet<TEyeStatusInfo> TEyeStatusInfos { get; set; }
        public DbSet<TGender> TGenders { get; set; }
        public DbSet<TGIInfo> TGIInfos { get; set; }
        public DbSet<THealthExam> THealthExams { get; set; }
        public DbSet<THeartInfo> THeartInfos { get; set; }
        public DbSet<TJobTitle> TJobTitles { get; set; }
        public DbSet<TLungInfo> TLungInfos { get; set; }
        public DbSet<TMedication> TMedications { get; set; }
        public DbSet<TMethod> TMethods { get; set; }
        public DbSet<TMouthInfo> TMouthInfos { get; set; }
        public DbSet<TMusculoskeletalInfo> TMusculoskeletalInfos { get; set; }
        public DbSet<TNeurologicalInfo> TNeurologicalInfos { get; set; }
        public DbSet<TNoseThroatInfo> TNoseThroatInfos { get; set; }
        public DbSet<TOwner> TOwners { get; set; }
        public DbSet<TPetImage> TPetImages { get; set; }
        public DbSet<TPet> TPets { get; set; }
        public DbSet<TPetType> TPetTypes { get; set; }
        public DbSet<TRole> TRoles { get; set; }
        public DbSet<TService> TServices { get; set; }
        public DbSet<TServiceType> TServiceTypes { get; set; }
        public DbSet<TSkinInfo> TSkinInfos { get; set; }
        public DbSet<TState> TStates { get; set; }
        public DbSet<TUrogenitalInfo> TUrogenitalInfos { get; set; }
        public DbSet<TUser> TUsers { get; set; }
        public DbSet<TVaccination> TVaccinations { get; set; }
        public DbSet<TVisitEmployee> TVisitEmployees { get; set; }
        public DbSet<TVisitMedication> TVisitMedications { get; set; }
        public DbSet<TVisitReason> TVisitReasons { get; set; }
        public DbSet<TVisit> TVisits { get; set; }
        public DbSet<TVisitService> TVisitServices { get; set; }
    }
}