using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Product.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EmailAndDateNowIsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufactureEmail",
                table: "Products",
                column: "ManufactureEmail",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProduceDate",
                table: "Products",
                column: "ProduceDate",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_ManufactureEmail",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProduceDate",
                table: "Products");
        }
    }
}
