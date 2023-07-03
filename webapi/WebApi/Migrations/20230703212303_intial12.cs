using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a25498ea-10fc-4995-bc05-e28200d5047c", "AQAAAAEAACcQAAAAEN0MGDO9WC9720TkzeiLYY3JXhXqnVZ4Rt4t/WnhUwrqq2xg1ZC22EmbsZTVCUVFNg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd30e54d-d0ec-4b3b-82b5-34f3f96440fd", "AQAAAAEAACcQAAAAEBsFzojASfIGBoft0p/ACELrtapFCra6fFulLJOrKW2PLvSpVAqVo1o29CB+6rRG+w==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2ad05a4a-e8bb-4c47-bc23-68c1c0230022", "AQAAAAEAACcQAAAAEA9YnfSfygm1LkWKKgNAZ8FlwNzY2PwGAOFKCWGTFucCl1QqEgfdlLYI2x8dgaozfA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
