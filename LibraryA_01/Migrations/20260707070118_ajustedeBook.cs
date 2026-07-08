using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryA_01.Migrations
{
    /// <inheritdoc />
    public partial class ajustedeBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "book");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "book",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "book",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "ISBN",
                table: "book",
                newName: "isbn");

            migrationBuilder.RenameColumn(
                name: "Available",
                table: "book",
                newName: "available");

            migrationBuilder.RenameColumn(
                name: "Author",
                table: "book",
                newName: "author");

            migrationBuilder.RenameColumn(
                name: "NumberOfPages",
                table: "book",
                newName: "number_of_pages");

            migrationBuilder.AlterColumn<int>(
                name: "year",
                table: "book",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "title",
                table: "book",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "isbn",
                table: "book",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "author",
                table: "book",
                type: "varchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "number_of_pages",
                table: "book",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                table: "book",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_book_isbn",
                table: "book",
                column: "isbn",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                table: "book");

            migrationBuilder.DropIndex(
                name: "IX_book_isbn",
                table: "book");

            migrationBuilder.RenameTable(
                name: "book",
                newName: "Books");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "Books",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Books",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "isbn",
                table: "Books",
                newName: "ISBN");

            migrationBuilder.RenameColumn(
                name: "available",
                table: "Books",
                newName: "Available");

            migrationBuilder.RenameColumn(
                name: "author",
                table: "Books",
                newName: "Author");

            migrationBuilder.RenameColumn(
                name: "number_of_pages",
                table: "Books",
                newName: "NumberOfPages");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Books",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "Books",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPages",
                table: "Books",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "Id");
        }
    }
}
