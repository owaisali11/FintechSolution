
using Fintech.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Fintech.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<User> ApplicationUser { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Code> Codes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
        public DbSet<Demographics> Demographics { get; set; }
        public DbSet<Durables> Durables { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Header> Headers { get; set; }
        public DbSet<HhCharacterstics> HhCharacterstics { get; set; }
        public DbSet<HhFacility> HhFacilities { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<SES> SESs { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Weight> Weights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UserRole>().HasNoKey();
          
           
           // modelBuilder.Entity<CustomAttributeData>().HasNoKey();
            // Other configurations
        }

    }
}
