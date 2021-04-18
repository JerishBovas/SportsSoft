using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsSoft.Models
{
    public class SportingContext : DbContext
    {
        public SportingContext(DbContextOptions<SportingContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Technician> Technicians { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country { CountryId = 1, CountryName = "India"},
                new Country { CountryId = 2, CountryName = "Canada" },
                new Country { CountryId = 3, CountryName = "Sri Lanka" },
                new Country { CountryId = 4, CountryName = "United States" },
                new Country { CountryId = 5, CountryName = "Autralia" },
                new Country { CountryId = 6, CountryName = "Japan" },
                new Country { CountryId = 7, CountryName = "Germany" },
                new Country { CountryId = 8, CountryName = "United Kingdom" },
                new Country { CountryId = 9, CountryName = "Norway" },
                new Country { CountryId = 10, CountryName = "Sweden" },
                new Country { CountryId = 11, CountryName = "France" },
                new Country { CountryId = 12, CountryName = "Italy" },
                new Country { CountryId = 13, CountryName = "Singapore" },
                new Country { CountryId = 14, CountryName = "Mexico" },
                new Country { CountryId = 15, CountryName = "Russia" },
                new Country { CountryId = 16, CountryName = "China" },
                new Country { CountryId = 17, CountryName = "Bangladesh" },
                new Country { CountryId = 18, CountryName = "Switzerland" },
                new Country { CountryId = 19, CountryName = "Malasiya" },
                new Country { CountryId = 20, CountryName = "Dubai" },
                new Country { CountryId = 21, CountryName = "Brazil" },
                new Country { CountryId = 22, CountryName = "Quatar" },
                new Country { CountryId = 23, CountryName = "Spain" },
                new Country { CountryId = 24, CountryName = "Saudi Arabia" },
                new Country { CountryId = 25, CountryName = "Pakistan" }
            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    CustomerId = 1,
                    FirstName = "John",
                    LastName = "Smith",
                    Address = "18 Elmhurst Drive",
                    City = "Etobicoke",
                    State = "Ontario",
                    PostalCode = "M9W4V4",
                    CountryId = 2,
                    Email = "John.Smith@gmail.com",
                    Phone = "4394850044"
                },
                new Customer
                {
                    CustomerId = 2,
                    FirstName = "James",
                    LastName = "Hellman",
                    Address = "149 Lincoln Street",
                    City = "New York",
                    State = "NY",
                    PostalCode = "443049",
                    CountryId = 4,
                    Email = "jameshellman@gmail.com",
                    Phone = "7829347829"
                },
                new Customer
                {
                    CustomerId = 3,
                    FirstName = "Franco",
                    LastName = "Wilbert",
                    Address = "433 Lesban Mt",
                    City = "Paris",
                    State = "Paris",
                    PostalCode = "429342",
                    CountryId = 11,
                    Email = "francowilbert@yahoo.com",
                    Phone = "4493204243"
                },
                new Customer
                {
                    CustomerId = 4,
                    FirstName = "Sundar",
                    LastName = "Mitchai",
                    Address = "15 arakkonam street",
                    City = "Avinasi",
                    State = "Tamil Nadu",
                    PostalCode = "622495",
                    CountryId = 1,
                    Email = "sundarmitchai@google.com",
                    Phone = "9448337294"
                }
            );
            modelBuilder.Entity<Technician>().HasData(
                new Technician
                {
                    TechnicianId =  1,
                    Name = "Hammer Khan",
                    Phone = "5583940022",
                    Email = "hammerkhan@sportsjas.com"
                },
                new Technician
                {
                    TechnicianId =  2,
                    Name = "Joseph Hand",
                    Phone = "8372940055",
                    Email = "josephhand@sportsjas.com"
                },
                new Technician
                {
                    TechnicianId =  3,
                    Name = "Hans Thomas",
                    Phone = "2945038593",
                    Email = "hansthomas@sportsjas.com"
                },
                new Technician
                {
                    TechnicianId =  4,
                    Name = "Peter Vijay",
                    Phone = "6739572288",
                    Email = "petervijay@sportsjas.com"
                }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ProductId = 1,
                    Code = "TRNY10",
                    Name = "Tournament Master 1.0",
                    Price = 4.99,
                    ReleaseDate = DateTime.Now
                },
                new Product
                {
                    ProductId = 2,
                    Code = "LEAG10",
                    Name = "League Scheduler 1.0",
                    Price = 4.99,
                    ReleaseDate = DateTime.Now
                },
                new Product
                {
                    ProductId = 3,
                    Code = "LEAGD10",
                    Name = "League Scheduler Deluxe 1.0",
                    Price = 7.99,
                    ReleaseDate = DateTime.Now
                },
                new Product
                {
                    ProductId = 4,
                    Code = "DRAFT10",
                    Name = "Draft Manager 1.0",
                    Price = 4.99,
                    ReleaseDate = DateTime.Now
                }
            );
            modelBuilder.Entity<Incident>().HasData(
                new Incident
                {
                    IncidentId = 1,
                    ProductId = 4,
                    CustomerId = 3,
                    TechnicianId = 1,
                    Title = "Could Not Install",
                    Description = "While Trying to install Draft manager it didnt install",
                    DateOpened = DateTime.Now
                },
                new Incident
                {
                    IncidentId = 2,
                    ProductId = 2,
                    CustomerId = 4,
                    TechnicianId = 3,
                    Title = "Unable to Install",
                    Description = "League Schedule is not installing and giving error",
                    DateOpened = DateTime.Now
                },
                new Incident
                {
                    IncidentId = 3,
                    ProductId = 3,
                    CustomerId = 2,
                    TechnicianId = 4,
                    Title = "Error Importing Data",
                    Description = "League Scheduler Deluxe is giving error importing data error",
                    DateOpened = DateTime.Now
                },
                new Incident
                {
                    IncidentId = 4,
                    ProductId = 1,
                    CustomerId = 2,
                    TechnicianId = 3,
                    Title = "Error Launching Program",
                    Description = "While Trying to launch tournament master, it crashes",
                    DateOpened = DateTime.Now
                }
            );
            modelBuilder.Entity<Registration>().HasData(
                new Registration
                {
                    RegistrationId = 1,
                    CustomerId = 3,
                    ProductId = 2
                },
                new Registration
                {
                    RegistrationId = 2,
                    CustomerId = 2,
                    ProductId = 2
                },
                new Registration
                {
                    RegistrationId = 3,
                    CustomerId = 4,
                    ProductId = 1
                },
                new Registration
                {
                    RegistrationId = 4,
                    CustomerId = 3,
                    ProductId = 3
                }
            );
        }
    }
}
