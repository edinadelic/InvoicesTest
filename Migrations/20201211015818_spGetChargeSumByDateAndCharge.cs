using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InvoiceTestApp.Migrations
{
    public partial class spGetChargeSumByDateAndCharge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string procedure = @"create Procedure spGetChargeSumByDateAndCharge
                @dateFrom datetime,
                @dateTo datetime,
                @chargeId int
                as
                Begin
                 SELECT SUM(Amount) AS AmountSum FROM [InvoiceDb].[dbo].[Invoices]
                 Where StartDate >= @dateFrom  and StartDate <= @dateTo 
                 and EndDate >= @dateFrom  and EndDate <= @dateTo and ChargeId = @chargeId
                End";
            migrationBuilder.Sql(procedure);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string procedure = @"Drop procedure spGetChargeSumByDateAndCharge";
            migrationBuilder.Sql(procedure);
        }
    }
}
