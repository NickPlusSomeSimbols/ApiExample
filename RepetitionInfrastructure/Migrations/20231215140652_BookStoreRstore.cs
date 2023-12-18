using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepetitionInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BookStoreRstore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookStorages_BookStorageId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookStorageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookStorageId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookStorages",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookId",
                table: "BookStorages",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookStorages_Books_BookId",
                table: "BookStorages",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookStorages_Books_BookId",
                table: "BookStorages");

            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookId",
                table: "BookStorages");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookStorages");

            migrationBuilder.AddColumn<int>(
                name: "BookStorageId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookStorageId",
                table: "Books",
                column: "BookStorageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookStorages_BookStorageId",
                table: "Books",
                column: "BookStorageId",
                principalTable: "BookStorages",
                principalColumn: "Id");
        }
    }
}
