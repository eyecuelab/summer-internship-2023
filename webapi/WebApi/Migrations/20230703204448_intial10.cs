using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1bfef7c8-89bf-4ce4-8cfa-1dab0840d368", "AQAAAAEAACcQAAAAEGvBkdCT5mzORo3/76v1eA++fzlewHULoieqcombgX7FjIQkejD7lfJffh75RvUw1Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "53f90ab6-6248-403f-af79-2119c1b926e7", "AQAAAAEAACcQAAAAEBnQJ8te3nYKYH2F4o3A8gQd1WHCVg5unuz4t7qBXXta3YoaApZ2NO8kw6VxYpTlDw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4bedea7e-66ce-4c9e-9c50-1bfba23840ba", "AQAAAAEAACcQAAAAEELtgr17teuqH83GgMf0chk/YQwXHvDu+f2WxJy4gI5INdtyE3ytRmo6EACLYSx+3w==" });
        }
    }
}
