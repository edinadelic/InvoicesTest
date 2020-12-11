using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceTestApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChargeName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ContactPerson = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_ClientAddresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "ClientAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceNumber = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rate = table.Column<double>(type: "float", nullable: false),
                    Units = table.Column<double>(type: "float", nullable: false),
                    Tax = table.Column<double>(type: "float", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    ChargeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Charges_ChargeId",
                        column: x => x.ChargeId,
                        principalTable: "Charges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoices_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Charges",
                columns: new[] { "Id", "ChargeName" },
                values: new object[,]
                {
                    { 1, "Day" },
                    { 2, "Night" },
                    { 3, "Weekend" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AddressId", "CompanyName", "ContactPerson", "Email", "IsActive", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, null, "BHTelecom", "Hamo Hamic", "bhtelecom@outlook.com", true, "060 555 666" },
                    { 2, null, "HT Mostar", "Anto Antic", "htmostar@outlook.com", true, "063 555 666" }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "ChargeId", "ClientId", "EndDate", "InvoiceDate", "InvoiceNumber", "Rate", "StartDate", "Tax", "Total", "Units" },
                values: new object[] { 1, 555.0, 1, 1, new DateTime(2020, 11, 26, 2, 56, 14, 968, DateTimeKind.Local).AddTicks(9126), new DateTime(2020, 12, 6, 2, 56, 14, 962, DateTimeKind.Local).AddTicks(8620), 123, 0.20000000000000001, new DateTime(2020, 10, 27, 2, 56, 14, 968, DateTimeKind.Local).AddTicks(7567), 0.17000000000000001, 888.0, 122.0 });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "Amount", "ChargeId", "ClientId", "EndDate", "InvoiceDate", "InvoiceNumber", "Rate", "StartDate", "Tax", "Total", "Units" },
                values: new object[] { 2, 899.0, 2, 1, new DateTime(2020, 11, 26, 2, 56, 14, 969, DateTimeKind.Local).AddTicks(8306), new DateTime(2020, 12, 6, 2, 56, 14, 969, DateTimeKind.Local).AddTicks(8222), 225, 0.29999999999999999, new DateTime(2020, 10, 27, 2, 56, 14, 969, DateTimeKind.Local).AddTicks(8278), 0.17000000000000001, 999.0, 356.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Charges_ChargeName",
                table: "Charges",
                column: "ChargeName",
                unique: true,
                filter: "[ChargeName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId",
                unique: true,
                filter: "[AddressId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_CompanyName",
                table: "Clients",
                column: "CompanyName",
                unique: true,
                filter: "[CompanyName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ChargeId",
                table: "Invoices",
                column: "ChargeId",
                unique: false);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientId",
                table: "Invoices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_InvoiceNumber_ClientId",
                table: "Invoices",
                columns: new[] { "InvoiceNumber", "ClientId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Charges");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ClientAddresses");
        }
    }
}
