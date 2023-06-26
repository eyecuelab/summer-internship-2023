using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Users",
                newName: "UserId");

            migrationBuilder.CreateTable(
                name: "EntityUser",
                columns: table => new
                {
                    EntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    EntityId1 = table.Column<string>(type: "text", nullable: true),
                    UserId1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityUser", x => x.EntityId);
                    table.ForeignKey(
                        name: "FK_EntityUser_Entities_EntityId1",
                        column: x => x.EntityId1,
                        principalTable: "Entities",
                        principalColumn: "EntityId");
                    table.ForeignKey(
                        name: "FK_EntityUser_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ProjectId1 = table.Column<string>(type: "text", nullable: true),
                    UserId1 = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_ProjectUser_Projects_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                    table.ForeignKey(
                        name: "FK_ProjectUser_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntityUser_EntityId1",
                table: "EntityUser",
                column: "EntityId1");

            migrationBuilder.CreateIndex(
                name: "IX_EntityUser_UserId1",
                table: "EntityUser",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_ProjectId1",
                table: "ProjectUser",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectUser_UserId1",
                table: "ProjectUser",
                column: "UserId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntityUser");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "Id");
        }
    }
}
