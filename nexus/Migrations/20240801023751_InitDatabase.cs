using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace nexus.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { new Guid("2461476f-2436-4a6e-882e-0dd2eb8fa5eb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User", "active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("8ad4db7f-bf2a-4eb3-b33c-d6bce38c656a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Admin", "active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "fullname", "image", "nik", "password", "role_id", "status", "updated_at", "username" },
                values: new object[] { new Guid("3663b4c8-edda-44b4-b793-de92090f68da"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Administrator", null, 101101021L, "$2a$11$h18ydm73pn5/iOGrvqaFXuiaN.lq0RgFA0.W7YJE.3qVR7gcgsS3.", new Guid("8ad4db7f-bf2a-4eb3-b33c-d6bce38c656a"), "active", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("2461476f-2436-4a6e-882e-0dd2eb8fa5eb"));

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "id",
                keyValue: new Guid("3663b4c8-edda-44b4-b793-de92090f68da"));

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "id",
                keyValue: new Guid("8ad4db7f-bf2a-4eb3-b33c-d6bce38c656a"));
        }
    }
}
