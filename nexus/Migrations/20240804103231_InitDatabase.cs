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
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    name = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    role_id = table.Column<Guid>(type: "uuid", nullable: true),
                    nik = table.Column<long>(type: "bigint", nullable: false),
                    image = table.Column<string>(type: "text", nullable: true),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                    table.ForeignKey(
                        name: "FK_users_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "posts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    category_id = table.Column<Guid>(type: "uuid", nullable: true),
                    title = table.Column<string>(type: "text", nullable: false),
                    article = table.Column<string>(type: "text", nullable: false),
                    slug = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: true),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_posts", x => x.id);
                    table.ForeignKey(
                        name: "FK_posts_categories_category_id",
                        column: x => x.category_id,
                        principalTable: "categories",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_posts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    post_id = table.Column<Guid>(type: "uuid", nullable: true),
                    fullname = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    comment = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                    table.ForeignKey(
                        name: "FK_comments_posts_post_id",
                        column: x => x.post_id,
                        principalTable: "posts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_comments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id");
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "created_at", "name", "updated_at" },
                values: new object[] { new Guid("df105327-3a71-431c-b8ca-b2a4a3065b45"), new DateTime(2024, 8, 4, 10, 32, 31, 43, DateTimeKind.Utc).AddTicks(9150), "MMORPG", new DateTime(2024, 8, 4, 10, 32, 31, 43, DateTimeKind.Utc).AddTicks(9152) });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { new Guid("774a46c6-ea74-48f8-8451-11dfddd405ce"), new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(2692), "Admin", "active", new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(2693) },
                    { new Guid("c0a3574d-b205-431c-a6fa-7bd8b138d610"), new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(2696), "User", "active", new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(2696) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "fullname", "image", "nik", "password", "role_id", "status", "updated_at", "username" },
                values: new object[] { new Guid("a25881b1-d522-4a71-b889-724da3084a81"), new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(7191), "admin@gmail.com", "Administrator", null, 76247031L, "$2a$11$wW2WZ8q5uGK4IHfLnO2TDuN4PPYmvW4JrPGkSiqMWtAPvNBbn8LJa", new Guid("774a46c6-ea74-48f8-8451-11dfddd405ce"), "active", new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(7191), "admin" });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "id", "article", "category_id", "created_at", "image", "slug", "status", "title", "updated_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("571f9934-c988-499b-b356-3c12215ab360"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("df105327-3a71-431c-b8ca-b2a4a3065b45"), new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(4695), null, "article-test-8DCB470BED092A2", "published", "Dummy Article", new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(4695), new Guid("a25881b1-d522-4a71-b889-724da3084a81") },
                    { new Guid("716f93dc-23e4-40f1-b0ef-f715416689f1"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("df105327-3a71-431c-b8ca-b2a4a3065b45"), new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(4383), null, "article-test-8DCB470BED09258", "published", "Article Test", new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(4384), new Guid("a25881b1-d522-4a71-b889-724da3084a81") },
                    { new Guid("e27daea5-d7af-4e98-aced-e4d7be1dc490"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("df105327-3a71-431c-b8ca-b2a4a3065b45"), new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(4652), null, "article-test-8DCB470BED09284", "published", "Article Test", new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(4652), new Guid("a25881b1-d522-4a71-b889-724da3084a81") },
                    { new Guid("e381d2b7-7e50-407b-a6da-8508046c8cb9"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("df105327-3a71-431c-b8ca-b2a4a3065b45"), new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(4679), null, "article-test-8DCB470BED09295", "published", "Article Test", new DateTime(2024, 8, 4, 10, 32, 31, 44, DateTimeKind.Utc).AddTicks(4679), new Guid("a25881b1-d522-4a71-b889-724da3084a81") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_name",
                table: "categories",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_comments_post_id",
                table: "comments",
                column: "post_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_user_id",
                table: "comments",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_category_id",
                table: "posts",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_posts_user_id",
                table: "posts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_roles_name",
                table: "roles",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_email",
                table: "users",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_nik",
                table: "users",
                column: "nik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_role_id",
                table: "users",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "posts");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
