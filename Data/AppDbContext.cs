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
    
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<ItemPhoto> ItemPhoto { get; set; }
        public DbSet<Bid> Bid { get; set; }
        public DbSet<ItemAgreement> ItemAgreement { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Semeia as categorias
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Eletrônicos" },
                new Category { Id = 2, Name = "Roupas" },
                new Category { Id = 3, Name = "Contrução" },
                new Category { Id = 4, Name = "Casa" }
            );

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}