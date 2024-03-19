using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConfessCorner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Confessions",
                columns: table => new
                {
                    ConfessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Header = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confessions", x => x.ConfessionId);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConfessionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Confessions_ConfessionId",
                        column: x => x.ConfessionId,
                        principalTable: "Confessions",
                        principalColumn: "ConfessionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ConfessionId",
                table: "Comments",
                column: "ConfessionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Confessions");
        }
    }
}
