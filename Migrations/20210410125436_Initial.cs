using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportsSoft.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_Customers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidents",
                columns: table => new
                {
                    IncidentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOpened = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateClosed = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidents", x => x.IncidentId);
                    table.ForeignKey(
                        name: "FK_Incidents_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidents_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Registrations",
                columns: table => new
                {
                    RegistrationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registrations", x => x.RegistrationId);
                    table.ForeignKey(
                        name: "FK_Registrations_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Registrations_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "India" },
                    { 25, "Pakistan" },
                    { 24, "Saudi Arabia" },
                    { 23, "Spain" },
                    { 22, "Quatar" },
                    { 21, "Brazil" },
                    { 20, "Dubai" },
                    { 19, "Malasiya" },
                    { 18, "Switzerland" },
                    { 16, "China" },
                    { 15, "Russia" },
                    { 14, "Mexico" },
                    { 17, "Bangladesh" },
                    { 12, "Italy" },
                    { 2, "Canada" },
                    { 3, "Sri Lanka" },
                    { 13, "Singapore" },
                    { 5, "Autralia" },
                    { 6, "Japan" },
                    { 4, "United States" },
                    { 8, "United Kingdom" },
                    { 9, "Norway" },
                    { 10, "Sweden" },
                    { 11, "France" },
                    { 7, "Germany" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Code", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "TRNY10", "Tournament Master 1.0", 4.9900000000000002, new DateTime(2021, 4, 10, 8, 54, 35, 367, DateTimeKind.Local).AddTicks(5553) },
                    { 2, "LEAG10", "League Scheduler 1.0", 4.9900000000000002, new DateTime(2021, 4, 10, 8, 54, 35, 372, DateTimeKind.Local).AddTicks(8902) },
                    { 3, "LEAGD10", "League Scheduler Deluxe 1.0", 7.9900000000000002, new DateTime(2021, 4, 10, 8, 54, 35, 372, DateTimeKind.Local).AddTicks(8979) },
                    { 4, "DRAFT10", "Draft Manager 1.0", 4.9900000000000002, new DateTime(2021, 4, 10, 8, 54, 35, 372, DateTimeKind.Local).AddTicks(8990) }
                });

            migrationBuilder.InsertData(
                table: "Technicians",
                columns: new[] { "TechnicianId", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 3, "hansthomas@sportsjas.com", "Hans Thomas", "2945038593" },
                    { 1, "hammerkhan@sportsjas.com", "Hammer Khan", "5583940022" },
                    { 2, "josephhand@sportsjas.com", "Joseph Hand", "8372940055" },
                    { 4, "petervijay@sportsjas.com", "Peter Vijay", "6739572288" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "City", "CountryId", "Email", "FirstName", "LastName", "Phone", "PostalCode", "State" },
                values: new object[,]
                {
                    { 4, "15 arakkonam street", "Avinasi", 1, "sundarmitchai@google.com", "Sundar", "Mitchai", "9448337294", "622495", "Tamil Nadu" },
                    { 1, "18 Elmhurst Drive", "Etobicoke", 2, "John.Smith@gmail.com", "John", "Smith", "4394850044", "M9W4V4", "Ontario" },
                    { 2, "149 Lincoln Street", "New York", 4, "jameshellman@gmail.com", "James", "Hellman", "7829347829", "443049", "NY" },
                    { 3, "433 Lesban Mt", "Paris", 11, "francowilbert@yahoo.com", "Franco", "Wilbert", "4493204243", "429342", "Paris" }
                });

            migrationBuilder.InsertData(
                table: "Incidents",
                columns: new[] { "IncidentId", "CustomerId", "DateClosed", "DateOpened", "Description", "ProductId", "TechnicianId", "Title" },
                values: new object[,]
                {
                    { 2, 4, null, new DateTime(2021, 4, 10, 8, 54, 35, 374, DateTimeKind.Local).AddTicks(4), "League Schedule is not installing and giving error", 2, 3, "Unable to Install" },
                    { 3, 2, null, new DateTime(2021, 4, 10, 8, 54, 35, 374, DateTimeKind.Local).AddTicks(48), "League Scheduler Deluxe is giving error importing data error", 3, 4, "Error Importing Data" },
                    { 4, 2, null, new DateTime(2021, 4, 10, 8, 54, 35, 374, DateTimeKind.Local).AddTicks(55), "While Trying to launch tournament master, it crashes", 1, 3, "Error Launching Program" },
                    { 1, 3, null, new DateTime(2021, 4, 10, 8, 54, 35, 373, DateTimeKind.Local).AddTicks(7429), "While Trying to install Draft manager it didnt install", 4, 1, "Could Not Install" }
                });

            migrationBuilder.InsertData(
                table: "Registrations",
                columns: new[] { "RegistrationId", "CustomerId", "ProductId" },
                values: new object[,]
                {
                    { 3, 4, 1 },
                    { 2, 2, 2 },
                    { 1, 3, 2 },
                    { 4, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_CustomerId",
                table: "Incidents",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_ProductId",
                table: "Incidents",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidents_TechnicianId",
                table: "Incidents",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_CustomerId",
                table: "Registrations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Registrations_ProductId",
                table: "Registrations",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Incidents");

            migrationBuilder.DropTable(
                name: "Registrations");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
