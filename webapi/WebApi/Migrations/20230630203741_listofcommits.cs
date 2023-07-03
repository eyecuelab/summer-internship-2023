using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class listofcommits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Commits",
                table: "Commits");

            migrationBuilder.RenameTable(
                name: "Commits",
                newName: "Commit");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "Commit",
                newName: "message");

            migrationBuilder.RenameColumn(
                name: "Sha",
                table: "Commit",
                newName: "sha");

            migrationBuilder.AddColumn<string>(
                name: "authorname",
                table: "Commit",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "comment_count",
                table: "Commit",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "committername",
                table: "Commit",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commit",
                table: "Commit",
                column: "sha");

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "Committer",
                columns: table => new
                {
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Committer", x => x.name);
                });

            migrationBuilder.CreateTable(
                name: "ListOfCommits",
                columns: table => new
                {
                    commitsha = table.Column<string>(type: "text", nullable: true),
                    authorname = table.Column<string>(type: "text", nullable: true),
                    committername = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ListOfCommits_Author_authorname",
                        column: x => x.authorname,
                        principalTable: "Author",
                        principalColumn: "name");
                    table.ForeignKey(
                        name: "FK_ListOfCommits_Commit_commitsha",
                        column: x => x.commitsha,
                        principalTable: "Commit",
                        principalColumn: "sha");
                    table.ForeignKey(
                        name: "FK_ListOfCommits_Committer_committername",
                        column: x => x.committername,
                        principalTable: "Committer",
                        principalColumn: "name");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8ec7dcf9-521d-402d-a82b-310b9665ba36", "AQAAAAEAACcQAAAAEHZuF7hL6f0M1DI1zkTxEQo2elF/PsTUEAhEcN8FIvOgQFTAJHX3bgXVEem79ncx8g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80e8b0ab-cccf-4b63-a350-436d433944ec", "AQAAAAEAACcQAAAAECkyJaDeTNh4EgNzwI0w9rtk0wc+XC+y0vt/HMC1N6pWGbkr9zhDOxrBzW2Oy3o59g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "2a70b5fa-525a-42e9-a1a6-5d9f70f9e5d3", "USER3", "AQAAAAEAACcQAAAAEPuP53aG8IFrbO+v1nWqkv/xhQuNXiOq7UWdg9bu9EMWTRn9J7QRrrmVmsNtS+PPWA==" });

            migrationBuilder.CreateIndex(
                name: "IX_Commit_authorname",
                table: "Commit",
                column: "authorname");

            migrationBuilder.CreateIndex(
                name: "IX_Commit_committername",
                table: "Commit",
                column: "committername");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCommits_authorname",
                table: "ListOfCommits",
                column: "authorname");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCommits_commitsha",
                table: "ListOfCommits",
                column: "commitsha");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCommits_committername",
                table: "ListOfCommits",
                column: "committername");

            migrationBuilder.AddForeignKey(
                name: "FK_Commit_Author_authorname",
                table: "Commit",
                column: "authorname",
                principalTable: "Author",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_Commit_Committer_committername",
                table: "Commit",
                column: "committername",
                principalTable: "Committer",
                principalColumn: "name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commit_Author_authorname",
                table: "Commit");

            migrationBuilder.DropForeignKey(
                name: "FK_Commit_Committer_committername",
                table: "Commit");

            migrationBuilder.DropTable(
                name: "ListOfCommits");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropTable(
                name: "Committer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commit",
                table: "Commit");

            migrationBuilder.DropIndex(
                name: "IX_Commit_authorname",
                table: "Commit");

            migrationBuilder.DropIndex(
                name: "IX_Commit_committername",
                table: "Commit");

            migrationBuilder.DropColumn(
                name: "authorname",
                table: "Commit");

            migrationBuilder.DropColumn(
                name: "comment_count",
                table: "Commit");

            migrationBuilder.DropColumn(
                name: "committername",
                table: "Commit");

            migrationBuilder.RenameTable(
                name: "Commit",
                newName: "Commits");

            migrationBuilder.RenameColumn(
                name: "message",
                table: "Commits",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "sha",
                table: "Commits",
                newName: "Sha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commits",
                table: "Commits",
                column: "Sha");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a6aa9d67-f74b-4255-8b1c-f6b43318cacb", "AQAAAAEAACcQAAAAELqGlH/DmzwFqCQAL4UU76vvi4BSIDyeqycQE+Jx22JXkXrK3dLMqDC+CuKVjD3NqQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { null, "AQAAAAEAACcQAAAAEC/3jCB4dKs+X9dliMYDuwFAcFZgy1HCTcwrhrxvtl1m939XnXGmi/dADoYBCqjRxw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash" },
                values: new object[] { "ab351440-d5a4-4feb-9e97-d94bb20e3c76", null, "AQAAAAEAACcQAAAAEP8JKYuCgH2XygdePi9u3qqekzeuft3wwc1AF4/Seci3zx7hKIXXPXLK6cWcVkS85Q==" });
        }
    }
}
