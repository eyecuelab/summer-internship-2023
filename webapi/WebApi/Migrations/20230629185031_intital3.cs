using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intital3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d6051f99-8e38-478d-a293-e7252bd4a7e2", "AQAAAAEAACcQAAAAECaG57QgOquCN+4fXuurpw/b1z7Hdeu4YtNzKSeqrFCMIh9p0W+2PLLRLFi8j31ZKw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d70a4145-b65f-4f70-983b-acd020d4212b", "AQAAAAEAACcQAAAAEGhwEF/k0mmMlZqrgJpjbq6Lo634ymTBBry6Hz+Pb3xi8S/bPf2ravATRiP+EeV9Kw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9f9594c5-474c-4dde-a59d-0eaedc3e27fe", "AQAAAAEAACcQAAAAEK/WsnbImbdD6iyjxDEw3AQu5YVnANYYGZiih2E9ry27OWyThmyOI2gyUZQZ1FzO0A==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "059e5b83-66a7-4fc7-b393-c64e3b1b0712", "AQAAAAEAACcQAAAAEDglqGO7ngRU2g4s+vD47UXO2eDRCYlJckpS8bQdsticsNrDaN2Mn8QXzQeMGCWK9A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "030d2431-16b3-4619-8728-abb47773b4da", "AQAAAAEAACcQAAAAENLesqDm+m/a8NWcBzpLxGUjAU7qmQ20eLMbCF4SsbpSxQYzVvf6Nr1R5xr4VRn4CA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cf706946-cdf9-4e08-97cb-3d8ea63d7424", "AQAAAAEAACcQAAAAEE6/HvLL88yxgPki95/9twKQzeKKGcDBWs4ti7v0HrtA02YL5oHVJLEiBN5P8CSUUA==" });
        }
    }
}
