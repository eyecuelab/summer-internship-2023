using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class keys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commits_Authors_authorname",
                table: "Commits");

            migrationBuilder.DropForeignKey(
                name: "FK_Commits_Committer_committername",
                table: "Commits");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCommits_Authors_authorname",
                table: "ListOfCommits");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCommits_Committer_committername",
                table: "ListOfCommits");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCommits_authorname",
                table: "ListOfCommits");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCommits_committername",
                table: "ListOfCommits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Committer",
                table: "Committer");

            migrationBuilder.DropIndex(
                name: "IX_Commits_authorname",
                table: "Commits");

            migrationBuilder.DropIndex(
                name: "IX_Commits_committername",
                table: "Commits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "authorname",
                table: "ListOfCommits");

            migrationBuilder.DropColumn(
                name: "committername",
                table: "ListOfCommits");

            migrationBuilder.DropColumn(
                name: "authorname",
                table: "Commits");

            migrationBuilder.DropColumn(
                name: "committername",
                table: "Commits");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Committer",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Committer",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "authorId",
                table: "Commits",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "committerId",
                table: "Commits",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Authors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Authors",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Committer",
                table: "Committer",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c6a327fc-55f3-428b-bd7c-9d4c215b05f9", "AQAAAAEAACcQAAAAEHou3pi+OQnPrmE8/jIdlCU8oe58D0448wKqq0pIp3KpmALr99DChTFw3CoRtMXlHw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fcf49200-4e62-4332-8dbf-4da1a2688625", "AQAAAAEAACcQAAAAEN9w2Tt1Dm6hm6QvgqRpCrQhyh0d5sX3dBZwvqB14sJ3Fq1Jt0WYnix3hNlIaEgeyQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f0d8d898-1f7c-47bf-9efd-8b0b6f41c6d1", "AQAAAAEAACcQAAAAEOK/w5vfrvDTekSO6mn1zYlADGlKNotr/sdazSWltyKu62pjaBlKBNIE39x8OSbD+w==" });

            migrationBuilder.CreateIndex(
                name: "IX_Commits_authorId",
                table: "Commits",
                column: "authorId");

            migrationBuilder.CreateIndex(
                name: "IX_Commits_committerId",
                table: "Commits",
                column: "committerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commits_Authors_authorId",
                table: "Commits",
                column: "authorId",
                principalTable: "Authors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commits_Committer_committerId",
                table: "Commits",
                column: "committerId",
                principalTable: "Committer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commits_Authors_authorId",
                table: "Commits");

            migrationBuilder.DropForeignKey(
                name: "FK_Commits_Committer_committerId",
                table: "Commits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Committer",
                table: "Committer");

            migrationBuilder.DropIndex(
                name: "IX_Commits_authorId",
                table: "Commits");

            migrationBuilder.DropIndex(
                name: "IX_Commits_committerId",
                table: "Commits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Committer");

            migrationBuilder.DropColumn(
                name: "authorId",
                table: "Commits");

            migrationBuilder.DropColumn(
                name: "committerId",
                table: "Commits");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Authors");

            migrationBuilder.AddColumn<string>(
                name: "authorname",
                table: "ListOfCommits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "committername",
                table: "ListOfCommits",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Committer",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "authorname",
                table: "Commits",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "committername",
                table: "Commits",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Authors",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Committer",
                table: "Committer",
                column: "name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4c15749-89bb-4e59-b3ce-f682ab68e54a", "AQAAAAEAACcQAAAAEPUYahMEWRpDxQSGtxibQvNY7SOstOwlI2i9V1iqNGhK+OI69GUEJLvXOThS7Q8geQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "485909fa-b0de-40b1-9549-754c6cd32bc4", "AQAAAAEAACcQAAAAEK2Q7VeqhMtvCyAF/cbttgcBTgC6BISE9r2oCwcbUu///CRzX7Fu7n42xuCidifgsQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "049be1c6-fa5e-4553-9d4a-2b059845bba7", "AQAAAAEAACcQAAAAEB1rZ+aGu2kmV14Yq2GJhKKQ+1tMqOoudpEJp6RZKN93c7wjkxnj3RtXjDfMTZvFmQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCommits_authorname",
                table: "ListOfCommits",
                column: "authorname");

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCommits_committername",
                table: "ListOfCommits",
                column: "committername");

            migrationBuilder.CreateIndex(
                name: "IX_Commits_authorname",
                table: "Commits",
                column: "authorname");

            migrationBuilder.CreateIndex(
                name: "IX_Commits_committername",
                table: "Commits",
                column: "committername");

            migrationBuilder.AddForeignKey(
                name: "FK_Commits_Authors_authorname",
                table: "Commits",
                column: "authorname",
                principalTable: "Authors",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_Commits_Committer_committername",
                table: "Commits",
                column: "committername",
                principalTable: "Committer",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCommits_Authors_authorname",
                table: "ListOfCommits",
                column: "authorname",
                principalTable: "Authors",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCommits_Committer_committername",
                table: "ListOfCommits",
                column: "committername",
                principalTable: "Committer",
                principalColumn: "name");
        }
    }
}
