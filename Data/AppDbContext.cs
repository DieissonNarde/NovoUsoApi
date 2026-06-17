using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NovoUsoApi.Models;

namespace NovoUsoApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }
    
        public DbSet<Item> Item { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Bid> Bid { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<ItemAgreement> ItemAgreement { get; set; }
        public DbSet<ItemPhoto> ItemPhoto { get; set; }
        public DbSet<User> User { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}