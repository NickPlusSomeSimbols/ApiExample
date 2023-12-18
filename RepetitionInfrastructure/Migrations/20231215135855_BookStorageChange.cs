using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepetitionInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BookStorageChange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookStorages_BookStores_BookStoreId",
                table: "BookStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_BookStorages_Books_BookId",
                table: "BookStorages");

            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookId",
                table: "BookStorages");

            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "BookStorages");

            migrationBuilder.AlterColumn<int>(
                name: "BookStorageId",
                table: "BookStores",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookStoreId",
                table: "BookStorages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BookAmount",
                table: "BookStorages",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BookStorageId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId",
                unique: true,
                filter: "[BookStoreId] IS NOT NULL");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookStorages_BookStores_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId",
                principalTable: "BookStores",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookStorages_BookStorageId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_BookStorages_BookStores_BookStoreId",
                table: "BookStorages");

            migrationBuilder.DropIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookStorageId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookStorageId",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookStorageId",
                table: "BookStores",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookStoreId",
                table: "BookStorages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BookAmount",
                table: "BookStorages",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "BookStorages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookId",
                table: "BookStorages",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookStorages_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStorages_BookStores_BookStoreId",
                table: "BookStorages",
                column: "BookStoreId",
                principalTable: "BookStores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookStorages_Books_BookId",
                table: "BookStorages",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
