using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
