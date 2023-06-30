using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commits",
                columns: table => new
                {
                    CommitId = table.Column<string>(type: "text", nullable: false),
                    Sha = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commits", x => x.CommitId);
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commits");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0f772653-099b-4877-bf4d-2b751d0b6984", "AQAAAAEAACcQAAAAEJEpzdYxgMl+RMJjzl+3EbL24qKe3+3jpD6xZF0Gt8+oBXKt4h3v1IcGRnlnU5lQMQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2dde6e78-dfa1-412c-931a-f1d7b619ae96", "AQAAAAEAACcQAAAAEO9smZ1x73LlU2BkxuBI/emYOlwZ5AZ7eLnh3vBFSHpOUNruZrGTLRlirMlrdhHxFQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81c67e4a-e3b9-4cc7-8aed-49ccc97d2988", "AQAAAAEAACcQAAAAELqCowDQvV+5VV5wvw2GOb6CwMfdtScSfHAQKYD+U+O54Nwu/RZqzts1xZvPg34NmA==" });
        }
    }
}
