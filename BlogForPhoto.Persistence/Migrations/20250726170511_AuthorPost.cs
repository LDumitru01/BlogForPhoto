using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogForPhoto.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AuthorPost : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AuthorUsername",
                table: "Posts",
                newName: "PostAuthor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostAuthor",
                table: "Posts",
                newName: "AuthorUsername");
        }
    }
}
