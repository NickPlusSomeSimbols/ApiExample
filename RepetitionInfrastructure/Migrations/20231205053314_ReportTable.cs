using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepetitionInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Books",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "BookSoldReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    BookStoreId = table.Column<int>(type: "int", nullable: false),
                    PurchaseAmount = table.Column<int>(type: "int", nullable: false),
                    Income = table.Column<float>(type: "real", nullable: false),
                    PuchaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookSoldReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookSoldReports_BookStores_BookStoreId",
                        column: x => x.BookStoreId,
                        principalTable: "BookStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookSoldReports_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookSoldReports_BookId",
                table: "BookSoldReports",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookSoldReports_BookStoreId",
                table: "BookSoldReports",
                column: "BookStoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookSoldReports");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");
        }
    }
}
