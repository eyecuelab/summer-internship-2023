using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class keyforcommit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCommits_Commits_commitsha",
                table: "ListOfCommits");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCommits_commitsha",
                table: "ListOfCommits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commits",
                table: "Commits");

            migrationBuilder.DropColumn(
                name: "commitsha",
                table: "ListOfCommits");

            migrationBuilder.AddColumn<int>(
                name: "commitId",
                table: "ListOfCommits",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sha",
                table: "Commits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Commits",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commits",
                table: "Commits",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5b596d9d-c1c1-42f1-955f-9edfe6460295", "AQAAAAEAACcQAAAAEMdfAZcjnlf0iEMNn+Yp0arWZ0hMjG+J/pDPb5y0i5QhlijNnudTQR1di9wnbZx0oQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "410817d9-8944-4090-a8bc-69cb1afb6eb9", "AQAAAAEAACcQAAAAECufuksxEakHFdZslOpBeQmlbQWYV563DbX0DbTQaPDUAGM1/MMR4dtH7egeAW5zQQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "22b14c7b-c174-428b-8fc6-d84f160b275d", "AQAAAAEAACcQAAAAEHFwljbOGmrcdml/3YK8B049jFzP0yv+pRXYzrs5afY+6cSg41f3TRfssLr4S4DOnw==" });

            migrationBuilder.CreateIndex(
                name: "IX_ListOfCommits_commitId",
                table: "ListOfCommits",
                column: "commitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCommits_Commits_commitId",
                table: "ListOfCommits",
                column: "commitId",
                principalTable: "Commits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCommits_Commits_commitId",
                table: "ListOfCommits");

            migrationBuilder.DropIndex(
                name: "IX_ListOfCommits_commitId",
                table: "ListOfCommits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commits",
                table: "Commits");

            migrationBuilder.DropColumn(
                name: "commitId",
                table: "ListOfCommits");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Commits");

            migrationBuilder.AddColumn<string>(
                name: "commitsha",
                table: "ListOfCommits",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "sha",
                table: "Commits",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commits",
                table: "Commits",
                column: "sha");

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
                name: "IX_ListOfCommits_commitsha",
                table: "ListOfCommits",
                column: "commitsha");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCommits_Commits_commitsha",
                table: "ListOfCommits",
                column: "commitsha",
                principalTable: "Commits",
                principalColumn: "sha");
        }
    }
}
