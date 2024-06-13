using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nexus.Migrations
{
    /// <inheritdoc />
    public partial class posts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "slug",
                table: "posts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "posts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "user_id",
                table: "posts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "slug",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "status",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "posts");
        }
    }
}
