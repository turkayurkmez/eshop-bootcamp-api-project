using eshop.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eshop.Data.Context
{
   public class EshopDbContext : DbContext
    {
        public EshopDbContext(DbContextOptions<EshopDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products  { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(p => p.Name).IsRequired()
                                                                .HasMaxLength(150);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                                          .WithMany(category => category.Products)
                                          .HasForeignKey(p => p.CategoryId)
                                          .OnDelete(DeleteBehavior.NoAction);

                                         

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

    }
}
