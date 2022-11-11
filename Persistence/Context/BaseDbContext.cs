using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Persistence.Context
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LanguageTechnology> LanguageTechnologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions,IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>(a =>
            {

                a.ToTable("Languages").HasKey(k => k.Id); //Priamry key configurartion
                a.Property(p => p.Id).HasColumnName("Id"); //Other configuration
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasMany(p => p.LanguageTechnologies);
            });



            modelBuilder.Entity<LanguageTechnology>(a =>
            {

                a.ToTable("LanguageTechnologies").HasKey(k => k.Id); //Priamry key configurartion
                a.Property(p => p.Id).HasColumnName("Id"); //Other configuration
               
                a.Property(p => p.LanguageId).HasColumnName("LanguageId");

                a.Property(p => p.Name).HasColumnName("Name");

                a.HasOne(p => p.Language);
            });
            

            Language[] languageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<Language>().HasData(languageEntitySeeds);

            LanguageTechnology[] languageTechnologyEntitySeeds = { new(3,1, "Asp.net") };
            modelBuilder.Entity<LanguageTechnology>().HasData(languageTechnologyEntitySeeds);


        }
      

    }
}
