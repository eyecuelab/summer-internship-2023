using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6b3a6bcf-0926-410d-8352-075f98f5a0a5", "AQAAAAEAACcQAAAAEG+JsRBJ8zzrjWIhLe+CuuUkQWrPs9NFLuN1CijJAjKCuLht84eOOJo1/a9JeA4UAg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "63cbc1d9-099a-4521-9dc9-5fdcd63cab55", "AQAAAAEAACcQAAAAEClc64BKclt5c9Z7WaVDFtd9FOrowZfUDHP6OLDm+uy09Hi/k89GdoXit2V3+l08Zg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dbea54dc-0959-450f-a522-fa3fec008243", "AQAAAAEAACcQAAAAED1kkECyIeuUmWTPii6QCwGirUN/cBqk2IF9kzQz6CeXSIXjI75Qi0RipU6t0y788w==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7ad9f889-98ab-4f61-81e0-a4be9164818c", "AQAAAAEAACcQAAAAEE89G8QBCJGyw3RzuCp0QAw1RQBjEfR1q4JxpbiGwSexjGPrwpjVId40t6ZhAkubjA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd67753d-5bfe-49cb-ab07-7d38e37ba46c", "AQAAAAEAACcQAAAAEAVWb+AYUPgJ3u1fN6/2UaAtWq1oPQioBP7VgL0aCsE79MRFQY8vMKAYPPJDeTQzOA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fabf6ecd-0ba8-4578-800a-ba3502d651fb", "AQAAAAEAACcQAAAAENEk72rJOmq/sW7jz+t9+/+gvNagKLlb0eAYithFmIYrkPYxkTZHx3xKO743vWqA1g==" });
        }
    }
}
