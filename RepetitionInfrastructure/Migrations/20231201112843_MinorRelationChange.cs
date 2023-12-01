using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepetitionInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MinorRelationChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookStorages_BookStores_BookStoreId",
                table: "BookStorages");

            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages");

            migrationBuilder.AddColumn<string>(
                name: "BookStorageId",
                table: "BookStores",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "BookStoreId",
                table: "BookStorages",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_BookStores_BookStorageId",
                table: "BookStores",
                column: "BookStorageId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStores_BookStorages_BookStorageId",
                table: "BookStores",
                column: "BookStorageId",
                principalTable: "BookStorages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookStores_BookStorages_BookStorageId",
                table: "BookStores");

            migrationBuilder.DropIndex(
                name: "IX_BookStores_BookStorageId",
                table: "BookStores");

            migrationBuilder.DropColumn(
                name: "BookStorageId",
                table: "BookStores");

            migrationBuilder.AlterColumn<string>(
                name: "BookStoreId",
                table: "BookStorages",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookStorages_BookStores_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId",
                principalTable: "BookStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
