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
                values: new object[] { new Guid("40210dde-c149-42fc-baf3-5477f9a1f9fb"), new DateTime(2024, 8, 4, 15, 16, 20, 639, DateTimeKind.Utc).AddTicks(8625), "MMORPG", new DateTime(2024, 8, 4, 15, 16, 20, 639, DateTimeKind.Utc).AddTicks(8627) });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_at", "name", "status", "updated_at" },
                values: new object[,]
                {
                    { new Guid("09c75270-321e-40d7-b7ad-1c5ebd1acd32"), new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(2328), "Admin", "active", new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(2329) },
                    { new Guid("8dad5d93-472a-4736-96c5-14432316fb93"), new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(2332), "User", "active", new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(2332) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "created_at", "email", "fullname", "image", "nik", "password", "role_id", "status", "updated_at", "username" },
                values: new object[] { new Guid("923e1e77-df01-44a6-a778-7843178c7138"), new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(7451), "admin@gmail.com", "Administrator", null, 37042529L, "$2a$11$rwqwi8ehg8.hgRcf111Jc.36ivkSHj3tk1R1FTHaEfP5YQXGH1XZS", new Guid("09c75270-321e-40d7-b7ad-1c5ebd1acd32"), "active", new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(7451), "admin" });

            migrationBuilder.InsertData(
                table: "posts",
                columns: new[] { "id", "article", "category_id", "created_at", "image", "slug", "status", "title", "updated_at", "user_id" },
                values: new object[,]
                {
                    { new Guid("27f3522e-3031-4bc8-81cc-90568f7dcbcd"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("40210dde-c149-42fc-baf3-5477f9a1f9fb"), new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(4752), null, "article-test-576b4c1", "published", "Article Test", new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(4753), new Guid("923e1e77-df01-44a6-a778-7843178c7138") },
                    { new Guid("2a032642-04ed-41d3-aca5-a0e52e44153c"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("40210dde-c149-42fc-baf3-5477f9a1f9fb"), new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(4769), null, "article-test-50e614a", "published", "Dummy Article", new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(4769), new Guid("923e1e77-df01-44a6-a778-7843178c7138") },
                    { new Guid("d4dfca10-5842-4a9a-86be-9fb93137bb51"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("40210dde-c149-42fc-baf3-5477f9a1f9fb"), new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(4464), null, "article-test-47219ac", "published", "Article Test", new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(4464), new Guid("923e1e77-df01-44a6-a778-7843178c7138") },
                    { new Guid("e646f47e-fd9a-49dd-8dbe-a8f72761a6c3"), "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.", new Guid("40210dde-c149-42fc-baf3-5477f9a1f9fb"), new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(4733), null, "article-test-3be7a81", "published", "Article Test", new DateTime(2024, 8, 4, 15, 16, 20, 640, DateTimeKind.Utc).AddTicks(4733), new Guid("923e1e77-df01-44a6-a778-7843178c7138") }
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
                name: "IX_posts_slug",
                table: "posts",
                column: "slug",
                unique: true);

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
