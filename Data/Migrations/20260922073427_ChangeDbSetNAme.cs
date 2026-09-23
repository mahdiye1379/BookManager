using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookManager.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDbSetNAme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_authors_AuthorId",
                table: "book");

            migrationBuilder.DropForeignKey(
                name: "FK_book_categories_CategoryId",
                table: "book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_categories",
                table: "categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_authors",
                table: "authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_book",
                table: "book");

            migrationBuilder.RenameTable(
                name: "categories",
                newName: "Categories");

            migrationBuilder.RenameTable(
                name: "authors",
                newName: "Authors");

            migrationBuilder.RenameTable(
                name: "book",
                newName: "Books");

            migrationBuilder.RenameIndex(
                name: "IX_book_CategoryId",
                table: "Books",
                newName: "IX_Books_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_book_AuthorId",
                table: "Books",
                newName: "IX_Books_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Books",
                table: "Books",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Authors_AuthorId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryId",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Books",
                table: "Books");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "categories");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "authors");

            migrationBuilder.RenameTable(
                name: "Books",
                newName: "book");

            migrationBuilder.RenameIndex(
                name: "IX_Books_CategoryId",
                table: "book",
                newName: "IX_book_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Books_AuthorId",
                table: "book",
                newName: "IX_book_AuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categories",
                table: "categories",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_authors",
                table: "authors",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_book",
                table: "book",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_book_authors_AuthorId",
                table: "book",
                column: "AuthorId",
                principalTable: "authors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_book_categories_CategoryId",
                table: "book",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
