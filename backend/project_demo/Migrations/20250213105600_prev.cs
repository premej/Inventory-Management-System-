using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace project_demo.Migrations
{
    /// <inheritdoc />
    public partial class prev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invoice_No",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "Invoice_No",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invoice_No",
                table: "products");

            migrationBuilder.AddColumn<int>(
                name: "Invoice_No",
                table: "Purchases",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
