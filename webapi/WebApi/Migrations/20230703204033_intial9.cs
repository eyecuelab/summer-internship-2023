using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c5c0dd13-c8b4-4f70-b876-03e6334c7c8e", "AQAAAAEAACcQAAAAENZ8n773d4EGvICP+dJ2h5iyuXlselTr2c1AM4JypKTwns4zTIi6jQ7cWiDcbZLS0g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bc78aa7-07ef-4bcb-a525-40131cc58555", "AQAAAAEAACcQAAAAEFR14rAuPnRnUlGyWV40q/e//YLJzHbY7OtYj9lmQGvO3CKTacajr2l+TgcdzNoG5A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "235767e2-3706-47ce-959f-93e633897905", "AQAAAAEAACcQAAAAEM6uin5ewBe44MHx7ESCyPJ+STKi/PqSfAfv6PeSYpIKJ7N4INiDj0FczBg6R7WYTw==" });
        }
    }
}
