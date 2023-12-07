using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepetitionInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BasketLogicChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "BasketItems",
                newName: "TotalPrice");

            migrationBuilder.AddColumn<int>(
                name: "TotalAmount",
                table: "BasketItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "BasketItems");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "BasketItems",
                newName: "Amount");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
