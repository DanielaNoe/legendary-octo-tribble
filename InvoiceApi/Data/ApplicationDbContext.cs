using Microsoft.EntityFrameworkCore;
using InvoiceApi.Models;

namespace InvoiceApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Position> Positions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(x => x.Addresses)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<Customer>()
                .HasMany(x => x.Orders)
                .WithOne(x => x.Customer)
                .HasForeignKey(x => x.CustomerId);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.Invoices)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.Positions)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId)
                .IsRequired();

            modelBuilder.Entity<Order>()
                .HasOne(x => x.BillingAddress)
                .WithMany(x => x.BillingOrders)
                .HasForeignKey(x => x.BillingAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.DeliveryAddress)
                .WithMany(x => x.DeliveryOrders)
                .HasForeignKey(x => x.DeliveryAddressId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Position>()
                .HasOne(x => x.Article)
                .WithMany(x => x.Positions)
                .HasForeignKey(x => x.ArticleId)
                .IsRequired();
        }
    }
}