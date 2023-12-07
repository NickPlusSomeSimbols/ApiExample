using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepetitionInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BasketMigrartionMinorFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalPrice",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Baskets");
        }
    }
}
