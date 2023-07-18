using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    EntityId = table.Column<string>(type: "text", nullable: true),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Committer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    email = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entities",
                columns: table => new
                {
                    EntityId = table.Column<string>(type: "text", nullable: false),
                    CompanyName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entities", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<string>(type: "text", nullable: false),
                    ProjectName = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                });

            migrationBuilder.CreateTable(
                name: "Sprints",
                columns: table => new
                {
                    TrelloSprintId = table.Column<string>(type: "text", nullable: false),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprints", x => x.TrelloSprintId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    commitSha = table.Column<string>(type: "text", nullable: true),
                    authorId = table.Column<int>(type: "integer", nullable: true),
                    committerId = table.Column<int>(type: "integer", nullable: true),
                    message = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    comment_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commits_Authors_authorId",
                        column: x => x.authorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Commits_Committer_committerId",
                        column: x => x.committerId,
                        principalTable: "Committer",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "emailEntities",
                columns: table => new
                {
                    EmailEntityId = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<string>(type: "text", nullable: false),
                    appUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emailEntities", x => x.EmailEntityId);
                    table.ForeignKey(
                        name: "FK_emailEntities_AspNetUsers_appUserId",
                        column: x => x.appUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_emailEntities_Entities_EntityId",
                        column: x => x.EntityId,
                        principalTable: "Entities",
                        principalColumn: "EntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAppUsers",
                columns: table => new
                {
                    ProjectAppUserId = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    appUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAppUsers", x => x.ProjectAppUserId);
                    table.ForeignKey(
                        name: "FK_ProjectAppUsers_AspNetUsers_appUserId",
                        column: x => x.appUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ProjectAppUsers_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId");
                });

            migrationBuilder.CreateTable(
                name: "ListOfCommits",
                columns: table => new
                {
                    sha = table.Column<string>(type: "text", nullable: true),
                    commitCount = table.Column<int>(type: "integer", nullable: false),
                    commitId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ListOfCommits_Commits_commitId",
                        column: x => x.commitId,
                        principalTable: "Commits",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "EntityId", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "44d7cbec-8c14-4952-b1b4-aca01b3f5313", "szook7@gmail.com", true, "ca2e28bc-1bd8-4e72-898c-edc028676877", false, false, null, "SZOOK7@GMAIL.COM", "SZOOK7@GMAIL.COM", "AQAAAAEAACcQAAAAEKK3QO+4ONyvhinZakXH9SLKnNck4ZYTLFkcGV7BRDdVq/s2fFLkl3OYS2UoZJzwQg==", null, false, "", false, "szook7@gmail.com" },
                    { "2", 0, "c7c3bb4b-20d3-4c12-87bd-48b710cd9351", "lee.justin001126@gmail.com", true, "ca2e28bc-1bd8-4e72-898c-edc028676877", true, false, null, "LEE.JUSTIN001126@GMAIL.COM", "LEE.JUSTIN001126@GMAIL.COM", "AQAAAAEAACcQAAAAEJHaMpQAF+HORm2rSvCCFADf7nYJkH4OXBvNzjfgvnc3mCngSZ3hb94uicHjnGKq3A==", null, false, "", false, "lee.justin001126@gmail.com" },
                    { "3", 0, "d6f9cd37-988a-41b4-8cd6-d4a2e7e0b840", "erintimlin@gmail.com", true, "ca2e28bc-1bd8-4e72-898c-edc028676877", true, false, null, "ERINTIMLIN@GMAIL.COM", "ERINTIMLIN@GMAIL.COM", "AQAAAAEAACcQAAAAEIB3KbGXrJB9QenRtzkufgGVlPD3iLGBPD62f9gBeQxWBti+c+b0CvpNzQta5VXVDA==", null, false, "", false, "erintimlin@gmail.com" },
                    { "4", 0, "2d9b23f1-384f-467c-a5fa-a0168c05072c", "gronstal.larson@gmail.com", true, "ca2e28bc-1bd8-4e72-898c-edc028676877", true, false, null, "GRONSTAL.LARSON@GMAIL.COM", "GRONSTAL.LARSON@GMAIL.COM", "AQAAAAEAACcQAAAAEPcvhllJxWdD+siSTXCsVANypvLmxI3qI7wq/lgOmfvrDPiS2jm7QFb7MTlY0UTkfg==", null, false, "", false, "Gronstal.Larson@gmail.com" },
                    { "5", 0, "f5bd79de-96bc-44e9-88d9-be5ade7a9959", "b.bakshev@gmail.com", true, "ca2e28bc-1bd8-4e72-898c-edc028676877", true, false, null, "B.BAKSHEV@GMAIL.COM", "B.BAKSHEV@GMAIL.COM", "AQAAAAEAACcQAAAAEInsm5xW68hrXN/gLi7gNVPcSiTvkjPlt734b7b3f3JLr6ETbTC1spcsz5hzzQeB5w==", null, false, "", false, "b.bakshev@gmail.com" },
                    { "6", 0, "b9aee73f-1998-4e7e-9f38-3054ebce53ea", "eliot.lauren@gmail.com", true, "ca2e28bc-1bd8-4e72-898c-edc028676877", false, false, null, "ELIOT.LAUREN@GMAIL.COM", "ELIOT.LAUREN@GMAIL.COM", "AQAAAAEAACcQAAAAEOLUmRy+7z+Xfcdm54h/Q8o7RIghGZvhv5HKXvYOy+Wma3mgFzeSRn1OE3vqdMHxKA==", null, false, "", false, "eliot.lauren@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Entities",
                columns: new[] { "EntityId", "CompanyName" },
                values: new object[,]
                {
                    { "98a29f8d-3129-4af1-831a-ff52c16a5c6d", "CocaCola" },
                    { "ca2e28bc-1bd8-4e72-898c-edc028676877", "EyeCue Lab" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "EntityId", "ProjectName" },
                values: new object[,]
                {
                    { "0ed8fcad-f106-4717-b313-751a41e1077a", "98a29f8d-3129-4af1-831a-ff52c16a5c6d", "CocaCola" },
                    { "9bf535b3-cf39-4374-8fbe-51a96bcef683", "ca2e28bc-1bd8-4e72-898c-edc028676877", "EyeCue Lab Project" }
                });

            migrationBuilder.InsertData(
                table: "ProjectAppUsers",
                columns: new[] { "ProjectAppUserId", "Email", "ProjectId", "appUserId" },
                values: new object[,]
                {
                    { "1", "szook7@gmail.com", "9bf535b3-cf39-4374-8fbe-51a96bcef683", null },
                    { "2", "lee.justin001126@gmail.com", "9bf535b3-cf39-4374-8fbe-51a96bcef683", null },
                    { "3", "erintimlin@gmail.com", "9bf535b3-cf39-4374-8fbe-51a96bcef683", null },
                    { "4", "Gronstal.Larson@gmail.com", "9bf535b3-cf39-4374-8fbe-51a96bcef683", null },
                    { "5", "b.bakshev@gmail.com", "9bf535b3-cf39-4374-8fbe-51a96bcef683", null },
                    { "6", "eliot.lauren@gmail.com", "9bf535b3-cf39-4374-8fbe-51a96bcef683", null }
                });

            migrationBuilder.InsertData(
                table: "emailEntities",
                columns: new[] { "EmailEntityId", "Email", "EntityId", "appUserId" },
                values: new object[,]
                {
                    { "1", "szook7@gmail.com", "ca2e28bc-1bd8-4e72-898c-edc028676877", null },
                    { "2", "lee.justin001126@gmail.com", "ca2e28bc-1bd8-4e72-898c-edc028676877", null },
                    { "3", "erintimlin@gmail.com", "ca2e28bc-1bd8-4e72-898c-edc028676877", null },
                    { "4", "Gronstal.Larson@gmail.com", "ca2e28bc-1bd8-4e72-898c-edc028676877", null },
                    { "5", "b.bakshev@gmail.com", "ca2e28bc-1bd8-4e72-898c-edc028676877", null },
                    { "6", "eliot.lauren@gmail.com", "ca2e28bc-1bd8-4e72-898c-edc028676877", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commits_authorId",
                table: "Commits",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_Commits_committerId",
                table: "Commits",
                column: "committerId");

            migrationBuilder.CreateIndex(
                name: "IX_emailEntities_appUserId",
                table: "emailEntities",
                column: "appUserId");

            migrationBuilder.CreateIndex(
                name: "IX_emailEntities_EntityId",
                table: "emailEntities",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCommits_commitId",
                table: "ListOfCommits",
                column: "commitId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAppUsers_appUserId",
                table: "ProjectAppUsers",
                column: "appUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAppUsers_ProjectId",
                table: "ProjectAppUsers",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "emailEntities");

            migrationBuilder.DropTable(
                name: "ListOfCommits");

            migrationBuilder.DropTable(
                name: "ProjectAppUsers");

            migrationBuilder.DropTable(
                name: "Sprints");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Entities");

            migrationBuilder.DropTable(
                name: "Commits");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Committer");
        }
    }
}
