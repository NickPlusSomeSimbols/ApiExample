using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepetitionInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BookStorageRelationshipChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages");

            migrationBuilder.DropColumn(
                name: "BookStorageId",
                table: "BookStores");

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages");

            migrationBuilder.AddColumn<int>(
                name: "BookStorageId",
                table: "BookStores",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId",
                unique: true,
                filter: "[BookStoreId] IS NOT NULL");
        }
    }
}
