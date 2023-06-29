using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Commits",
                table: "Commits");

            migrationBuilder.DropColumn(
                name: "CommitId",
                table: "Commits");

            migrationBuilder.AlterColumn<string>(
                name: "Sha",
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
                values: new object[] { "ac627e06-06c0-4d34-abb1-6114795b6cc0", "AQAAAAEAACcQAAAAEC/3jCB4dKs+X9dliMYDuwFAcFZgy1HCTcwrhrxvtl1m939XnXGmi/dADoYBCqjRxw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4a2f68d4-ddd8-4ad5-9989-c05ec5b45bd9", "AQAAAAEAACcQAAAAEP8JKYuCgH2XygdePi9u3qqekzeuft3wwc1AF4/Seci3zx7hKIXXPXLK6cWcVkS85Q==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Commits",
                table: "Commits");

            migrationBuilder.AlterColumn<string>(
                name: "Sha",
                table: "Commits",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "CommitId",
                table: "Commits",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commits",
                table: "Commits",
                column: "CommitId");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "706e59a0-eeaa-46c9-bdac-0432456a70e4", "AQAAAAEAACcQAAAAEBe6wAazvX0cgGr+E36lfl2PZzJ2JLBrMeJQQ/d2Anim4vA9br3z5TlXCW0AslbMRw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "19d4d487-762a-4087-aa9f-248308306b1b", "AQAAAAEAACcQAAAAEOBb7y9poR9cZj44uNVfGxmgRA2Toryei+gyFAbfV9Qdg62yN+x+uTc53TTIf2Wesw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7406574c-4998-4ec2-bb97-cc80cab31d1e", "AQAAAAEAACcQAAAAEJC+vGmOciSxyHcPb6mJtSbZLq+yBnRruhTnIUBDQzqRP1ukKrDAne1THqDis4M1cQ==" });
        }
    }
}
