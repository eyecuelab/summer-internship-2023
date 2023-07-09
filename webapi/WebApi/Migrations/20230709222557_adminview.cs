using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class adminview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityAppUsers");

            migrationBuilder.AlterColumn<string>(
                name: "EntityId",
                table: "Projects",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "EntityId",
                table: "Projects",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateTable(
                name: "EntityAppUsers",
                columns: table => new
                {
                    EntityAppUserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppUserId = table.Column<string>(type: "text", nullable: true),
                    EntityId1 = table.Column<string>(type: "text", nullable: true),
                    EntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityAppUsers", x => x.EntityAppUserId);
                    table.ForeignKey(
                        name: "FK_EntityAppUsers_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityAppUsers_Entities_EntityId1",
                        column: x => x.EntityId1,
                        principalTable: "Entities",
                        principalColumn: "EntityId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityAppUsers_AppUserId",
                table: "EntityAppUsers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAppUsers_EntityId1",
                table: "EntityAppUsers",
                column: "EntityId1");
        }
    }
}
