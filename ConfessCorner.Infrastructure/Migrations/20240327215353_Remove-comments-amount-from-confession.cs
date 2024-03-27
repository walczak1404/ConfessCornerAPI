using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfessCorner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Removecommentsamountfromconfession : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentAmount",
                table: "Confessions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentAmount",
                table: "Confessions",
                type: "int",
                nullable: true);
        }
    }
}
