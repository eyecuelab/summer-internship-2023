using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class commitsha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "sha",
                table: "Commits",
                newName: "commitSha");

            migrationBuilder.AddColumn<string>(
                name: "sha",
                table: "ListOfCommits",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "95742da4-eb44-4461-a836-ea41edcda94e", "AQAAAAEAACcQAAAAEPBOuapXIHkxBFjlx//XzFgKQqOFAbWYtZSc8FJijL6LXFbTs7bOIFV+QJyDklFhxA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e7ea0574-efbf-454d-91d4-7d670cd6869b", "AQAAAAEAACcQAAAAEJzLI2Px1+K65U+xBQrg92S2mZgAhy6cB1QuCzlWcqhQuCckWK9TcaWM/Qloa7nNYA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c1edb3c9-7fc0-45b0-a989-a5676f77938e", "AQAAAAEAACcQAAAAENqlBzVGZywqkQuwsN+D8bv7ERpLYKajgF89Y+S3oH1cSFzb0yG0Kuvs0rMh52jeqw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "sha",
                table: "ListOfCommits");

            migrationBuilder.RenameColumn(
                name: "commitSha",
                table: "Commits",
                newName: "sha");

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
        }
    }
}
