using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectAppUsers_Projects_ProjectId",
                table: "ProjectAppUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectAppUsers_ProjectId",
                table: "ProjectAppUsers");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Projects",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId1",
                table: "ProjectAppUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "EntityId", "IsAdmin", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "86d161f2-2831-4df9-ae17-6487c0565d0c", "szook7@gmail.com", true, "1", true, false, null, "SZOOK7@GMAIL.COM", "SZOOK7@GMAIL.COM", "AQAAAAEAACcQAAAAEEFzc13GaNr92A+Nkl75oRY6u3i2qfNh+leaLGGgq3wSIs+r+wHg5S0vNNS2INUOMA==", null, false, "", false, "szook7@gmail.com" },
                    { "2", 0, "24c37ee6-2768-41c6-bb78-4dda810b09e8", "lee.justin001126@gmail.com", true, "1", true, false, null, "LEE.JUSTIN001126@GMAIL.COM", "LEE.JUSTIN001126@GMAIL.COM", "AQAAAAEAACcQAAAAEDWxZQl0XFHx/Eyc8IXqrLiSjaH87jD96qJkr2UZRleQjDTIwhxaMpJ5DRboWR4nkw==", null, false, "", false, "lee.justin001126@gmail.com" },
                    { "3", 0, "b87779c6-ac61-469d-b5f2-7dc9ebd67e73", "erintimlin@gmail.com", true, "0", true, false, null, "ERINTIMLIN@GMAIL.COM", "ERINTIMLIN@GMAIL.COM", "AQAAAAEAACcQAAAAEE1XhpT725QWJ0iVVTkJfzzDcweWYcC/2KfK+Xl6A/OtJPIkmabEuKnZaqLxun9Ylw==", null, false, "", false, "erintimlin@gmail.com" },
                    { "4", 0, "0e903216-4128-4881-96dc-f45a93c0dd15", "gronstal.larson@gmail.com", true, "0", true, false, null, "GRONSTAL.LARSON@GMAIL.COM", "GRONSTAL.LARSON@GMAIL.COM", "AQAAAAEAACcQAAAAEMxYS/s1jyEBGLNLirV50NBG/7pooc18DCJI8awnA6YuXjA9FsI4obgc0U+ora7I6g==", null, false, "", false, "Gronstal.Larson@gmail.com" },
                    { "5", 0, "02e32048-ac2b-4953-a31d-026a39397bce", "b.bakshev@gmail.com", true, "0", true, false, null, "B.BAKSHEV@GMAIL.COM", "B.BAKSHEV@GMAIL.COM", "AQAAAAEAACcQAAAAEB9Omwvukxtve0+KHtrMyS9NAtYN+jjdjHWmQyrdqxuXCW5QD170foAvZvJz1oLQ4Q==", null, false, "", false, "b.bakshev@gmail.com" },
                    { "6", 0, "79aa3226-80e5-4780-9d96-bb786c5a8d08", "eliot.lauren@gmail.com", true, "0", true, false, null, "ELIOT.LAUREN@GMAIL.COM", "ELIOT.LAUREN@GMAIL.COM", "AQAAAAEAACcQAAAAEEGarjCmiIxmaCtz3DA83qoLYrfr7OZMiG5toUJZc1qm2e3YzPeMqUL1snFFsKWaXA==", null, false, "", false, "eliot.lauren@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "Entities",
                columns: new[] { "EntityId", "CompanyName" },
                values: new object[,]
                {
                    { "0", "Devkoda" },
                    { "1", "EyeCue Lab" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "EntityId", "ProjectName" },
                values: new object[,]
                {
                    { 1, "1", "EyeCue Lab Project" },
                    { 2, "0", "Devkoda Project" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAppUsers_ProjectId1",
                table: "ProjectAppUsers",
                column: "ProjectId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectAppUsers_Projects_ProjectId1",
                table: "ProjectAppUsers",
                column: "ProjectId1",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectAppUsers_Projects_ProjectId1",
                table: "ProjectAppUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProjectAppUsers_ProjectId1",
                table: "ProjectAppUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: "0");

            migrationBuilder.DeleteData(
                table: "Entities",
                keyColumn: "EntityId",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "ProjectAppUsers");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectId",
                table: "Projects",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAppUsers_ProjectId",
                table: "ProjectAppUsers",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectAppUsers_Projects_ProjectId",
                table: "ProjectAppUsers",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "ProjectId");
        }
    }
}
