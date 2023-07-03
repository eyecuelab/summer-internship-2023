using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class commitdetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "71bb2951-cef7-44a4-b4ef-b33060eddf0d", "AQAAAAEAACcQAAAAEBi2/1pz9KeHqj8BQR6Wq1hwEuDZYvtO7Dv5rhiF7u14czguAa6oCuwqiv4AlwIW5w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5a9e6e0e-cca2-4457-b6cf-add3198122f2", "AQAAAAEAACcQAAAAEOiZguLTXp4W9PqiYl09GHMNkbh0UxSDiTiXombB5IoIy3uxLCq1iZteIQPs54NSTA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f8f88ca1-b48c-4b94-8da5-877a5ab86a0f", "AQAAAAEAACcQAAAAEBk87VtMjsu+LB76VBqm1Z234AMgbNr7mNIF7ntybKIvnsYOL0nqNOoM1lGgc1vkMg==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
