 using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace StoreApp
{
    public class Store_DbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<OrderPrompt> OrderProducts { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        //public DbSet<CustomersCollection> c_Collection { get; set; }
        public DbSet<Order> Orders { get; set; }

        public Store_DbContext() { }

        public Store_DbContext(DbContextOptions<Store_DbContext> options)
            : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("Server= DESKTOP-KGITG3T; Database=Store1; Trusted_connection = true;");
            }
        }

        //Override how Store_DbContext is creating the model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(e =>   
            {
                e.HasKey(customer => customer.Id);  //sets the ID property for customer
            });


            modelBuilder.Entity<DbTuple<Product, int, Order>>(e =>
            {
                e.ToTable("OrderedProducts");
                e.HasOne(t => t.ForeignObject)
                .WithMany(o => o.Products)
                .HasForeignKey(t => t.ForeignId);//configures teh property to use as the FK
            });

            modelBuilder.Entity<OrderPrompt>(e =>
            {
                e.HasNoKey();
            });
        }

/*        OnModelCreating is a way to tell migrations how to build the database, 
with the tuple migrations didn't know how the build the database 
when tuple is used (No DB supports having 2 values in the same column) 
Added DbTuple -> tell migrations create 2 columns for the Tuple instead of 1 column*/
    }

}

