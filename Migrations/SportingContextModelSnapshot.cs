﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SportsSoft.Models;

namespace SportsSoft.Migrations
{
    [DbContext(typeof(SportingContext))]
    partial class SportingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsSoft.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "India"
                        },
                        new
                        {
                            CountryId = 2,
                            CountryName = "Canada"
                        },
                        new
                        {
                            CountryId = 3,
                            CountryName = "Sri Lanka"
                        },
                        new
                        {
                            CountryId = 4,
                            CountryName = "United States"
                        },
                        new
                        {
                            CountryId = 5,
                            CountryName = "Autralia"
                        },
                        new
                        {
                            CountryId = 6,
                            CountryName = "Japan"
                        },
                        new
                        {
                            CountryId = 7,
                            CountryName = "Germany"
                        },
                        new
                        {
                            CountryId = 8,
                            CountryName = "United Kingdom"
                        },
                        new
                        {
                            CountryId = 9,
                            CountryName = "Norway"
                        },
                        new
                        {
                            CountryId = 10,
                            CountryName = "Sweden"
                        },
                        new
                        {
                            CountryId = 11,
                            CountryName = "France"
                        },
                        new
                        {
                            CountryId = 12,
                            CountryName = "Italy"
                        },
                        new
                        {
                            CountryId = 13,
                            CountryName = "Singapore"
                        },
                        new
                        {
                            CountryId = 14,
                            CountryName = "Mexico"
                        },
                        new
                        {
                            CountryId = 15,
                            CountryName = "Russia"
                        },
                        new
                        {
                            CountryId = 16,
                            CountryName = "China"
                        },
                        new
                        {
                            CountryId = 17,
                            CountryName = "Bangladesh"
                        },
                        new
                        {
                            CountryId = 18,
                            CountryName = "Switzerland"
                        },
                        new
                        {
                            CountryId = 19,
                            CountryName = "Malasiya"
                        },
                        new
                        {
                            CountryId = 20,
                            CountryName = "Dubai"
                        },
                        new
                        {
                            CountryId = 21,
                            CountryName = "Brazil"
                        },
                        new
                        {
                            CountryId = 22,
                            CountryName = "Quatar"
                        },
                        new
                        {
                            CountryId = 23,
                            CountryName = "Spain"
                        },
                        new
                        {
                            CountryId = 24,
                            CountryName = "Saudi Arabia"
                        },
                        new
                        {
                            CountryId = 25,
                            CountryName = "Pakistan"
                        });
                });

            modelBuilder.Entity("SportsSoft.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "18 Elmhurst Drive",
                            City = "Etobicoke",
                            CountryId = 2,
                            Email = "John.Smith@gmail.com",
                            FirstName = "John",
                            LastName = "Smith",
                            Phone = "4394850044",
                            PostalCode = "M9W4V4",
                            State = "Ontario"
                        },
                        new
                        {
                            CustomerId = 2,
                            Address = "149 Lincoln Street",
                            City = "New York",
                            CountryId = 4,
                            Email = "jameshellman@gmail.com",
                            FirstName = "James",
                            LastName = "Hellman",
                            Phone = "7829347829",
                            PostalCode = "443049",
                            State = "NY"
                        },
                        new
                        {
                            CustomerId = 3,
                            Address = "433 Lesban Mt",
                            City = "Paris",
                            CountryId = 11,
                            Email = "francowilbert@yahoo.com",
                            FirstName = "Franco",
                            LastName = "Wilbert",
                            Phone = "4493204243",
                            PostalCode = "429342",
                            State = "Paris"
                        },
                        new
                        {
                            CustomerId = 4,
                            Address = "15 arakkonam street",
                            City = "Avinasi",
                            CountryId = 1,
                            Email = "sundarmitchai@google.com",
                            FirstName = "Sundar",
                            LastName = "Mitchai",
                            Phone = "9448337294",
                            PostalCode = "622495",
                            State = "Tamil Nadu"
                        });
                });

            modelBuilder.Entity("SportsSoft.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 3,
                            DateOpened = new DateTime(2021, 4, 10, 8, 54, 35, 373, DateTimeKind.Local).AddTicks(7429),
                            Description = "While Trying to install Draft manager it didnt install",
                            ProductId = 4,
                            TechnicianId = 1,
                            Title = "Could Not Install"
                        },
                        new
                        {
                            IncidentId = 2,
                            CustomerId = 4,
                            DateOpened = new DateTime(2021, 4, 10, 8, 54, 35, 374, DateTimeKind.Local).AddTicks(4),
                            Description = "League Schedule is not installing and giving error",
                            ProductId = 2,
                            TechnicianId = 3,
                            Title = "Unable to Install"
                        },
                        new
                        {
                            IncidentId = 3,
                            CustomerId = 2,
                            DateOpened = new DateTime(2021, 4, 10, 8, 54, 35, 374, DateTimeKind.Local).AddTicks(48),
                            Description = "League Scheduler Deluxe is giving error importing data error",
                            ProductId = 3,
                            TechnicianId = 4,
                            Title = "Error Importing Data"
                        },
                        new
                        {
                            IncidentId = 4,
                            CustomerId = 2,
                            DateOpened = new DateTime(2021, 4, 10, 8, 54, 35, 374, DateTimeKind.Local).AddTicks(55),
                            Description = "While Trying to launch tournament master, it crashes",
                            ProductId = 1,
                            TechnicianId = 3,
                            Title = "Error Launching Program"
                        });
                });

            modelBuilder.Entity("SportsSoft.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Code = "TRNY10",
                            Name = "Tournament Master 1.0",
                            Price = 4.9900000000000002,
                            ReleaseDate = new DateTime(2021, 4, 10, 8, 54, 35, 367, DateTimeKind.Local).AddTicks(5553)
                        },
                        new
                        {
                            ProductId = 2,
                            Code = "LEAG10",
                            Name = "League Scheduler 1.0",
                            Price = 4.9900000000000002,
                            ReleaseDate = new DateTime(2021, 4, 10, 8, 54, 35, 372, DateTimeKind.Local).AddTicks(8902)
                        },
                        new
                        {
                            ProductId = 3,
                            Code = "LEAGD10",
                            Name = "League Scheduler Deluxe 1.0",
                            Price = 7.9900000000000002,
                            ReleaseDate = new DateTime(2021, 4, 10, 8, 54, 35, 372, DateTimeKind.Local).AddTicks(8979)
                        },
                        new
                        {
                            ProductId = 4,
                            Code = "DRAFT10",
                            Name = "Draft Manager 1.0",
                            Price = 4.9900000000000002,
                            ReleaseDate = new DateTime(2021, 4, 10, 8, 54, 35, 372, DateTimeKind.Local).AddTicks(8990)
                        });
                });

            modelBuilder.Entity("SportsSoft.Models.Registration", b =>
                {
                    b.Property<int>("RegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("RegistrationId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Registrations");

                    b.HasData(
                        new
                        {
                            RegistrationId = 1,
                            CustomerId = 3,
                            ProductId = 2
                        },
                        new
                        {
                            RegistrationId = 2,
                            CustomerId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            RegistrationId = 3,
                            CustomerId = 4,
                            ProductId = 1
                        },
                        new
                        {
                            RegistrationId = 4,
                            CustomerId = 3,
                            ProductId = 3
                        });
                });

            modelBuilder.Entity("SportsSoft.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            Email = "hammerkhan@sportsjas.com",
                            Name = "Hammer Khan",
                            Phone = "5583940022"
                        },
                        new
                        {
                            TechnicianId = 2,
                            Email = "josephhand@sportsjas.com",
                            Name = "Joseph Hand",
                            Phone = "8372940055"
                        },
                        new
                        {
                            TechnicianId = 3,
                            Email = "hansthomas@sportsjas.com",
                            Name = "Hans Thomas",
                            Phone = "2945038593"
                        },
                        new
                        {
                            TechnicianId = 4,
                            Email = "petervijay@sportsjas.com",
                            Name = "Peter Vijay",
                            Phone = "6739572288"
                        });
                });

            modelBuilder.Entity("SportsSoft.Models.Customer", b =>
                {
                    b.HasOne("SportsSoft.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SportsSoft.Models.Incident", b =>
                {
                    b.HasOne("SportsSoft.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsSoft.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsSoft.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("SportsSoft.Models.Registration", b =>
                {
                    b.HasOne("SportsSoft.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SportsSoft.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });
#pragma warning restore 612, 618
        }
    }
}
