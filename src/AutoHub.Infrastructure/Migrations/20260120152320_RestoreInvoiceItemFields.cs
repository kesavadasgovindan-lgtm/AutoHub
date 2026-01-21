using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoHub.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RestoreInvoiceItemFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsCancelled",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "MakeModel",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PaymentMode",
                table: "Invoices");

            migrationBuilder.RenameColumn(
                name: "VehicleNumber",
                table: "Invoices",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "GrossAmount",
                table: "Invoices",
                newName: "SubTotal");

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "Invoices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "QuotationId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Discount",
                table: "InvoiceItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Invoices_InvoiceId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "QuotationId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Discount",
                table: "InvoiceItems");

            migrationBuilder.RenameColumn(
                name: "SubTotal",
                table: "Invoices",
                newName: "GrossAmount");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Invoices",
                newName: "VehicleNumber");

            migrationBuilder.AddColumn<bool>(
                name: "IsCancelled",
                table: "Invoices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MakeModel",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMode",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
