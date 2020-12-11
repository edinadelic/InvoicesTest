using InvoiceTestApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceTestApp.ViewModels;

namespace InvoiceTestApp.Data
{
    public class DataContex : DbContext
    {
        public DataContex(DbContextOptions<DataContex> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ClientAddress>()
                       .HasOne(c => c.Client)
                       .WithOne(ad => ad.ClientAddress)
                       .HasForeignKey<Client>(a => a.AddressId);

            //builder.Entity<Charge>()
            //           .HasOne(c => c.Invoice)
            //           .WithOne(ad => ad.Charge)
            //           .HasForeignKey<Invoice>(i => i.ChargeId);

            //builder.Entity<Client>()
            //       .HasMany(c => c.Invoices)
            //       .WithOne(i => i.Client)
            //       .IsRequired();

            builder.Entity<Client>()
                       .HasIndex(u => u.CompanyName)
                       .IsUnique();

            builder.Entity<Charge>()
                       .HasIndex(u => u.ChargeName)
                       .IsUnique();

            builder.Entity<Invoice>()
                       .HasIndex(p => new { p.InvoiceNumber, p.ClientId }).IsUnique();

            builder.Entity<Invoice>()
                     .HasOne(c => c.Charge)
                     .WithOne(ad => ad.Invoice)
                     .HasForeignKey<Invoice>(i => i.ChargeId);

            builder.Entity<Charge>().HasData(

                new Charge { Id = 1, ChargeName = "Day" },
                new Charge { Id = 2, ChargeName = "Night" },
                new Charge { Id = 3, ChargeName = "Weekend" }
               );

            builder.Entity<Client>().HasData(

                new Client { Id = 1, CompanyName = "BHTelecom", ContactPerson = "Hamo Hamic", Email = "bhtelecom@outlook.com", IsActive = true, PhoneNumber = "060 555 666"},
                new Client { Id = 2, CompanyName = "HT Mostar", ContactPerson = "Anto Antic", Email = "htmostar@outlook.com", IsActive = true, PhoneNumber = "063 555 666" }
                );

            builder.Entity<Invoice>().HasData(

                new Invoice { Id = 1, ClientId = 1, InvoiceNumber = 123, InvoiceDate = DateTime.Now.AddDays(-5), StartDate = DateTime.Now.AddDays(-45), EndDate = DateTime.Now.AddDays(-15), Rate = 0.2, Units = 122, ChargeId = 1, Tax = 0.17, Amount = 555, Total = 888},

                new Invoice { Id = 2, ClientId = 1, InvoiceNumber = 225, InvoiceDate = DateTime.Now.AddDays(-5), StartDate= DateTime.Now.AddDays(-45), EndDate = DateTime.Now.AddDays(-15), Rate = 0.3, Units = 356, Tax = 0.17, ChargeId = 2, Amount = 899, Total = 999}
                );
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientAddress> ClientAddresses { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Charge> Charges { get; set; }
    }
}
