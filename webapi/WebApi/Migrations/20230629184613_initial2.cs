using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ea0fef85-19f1-4415-8388-cf6c867d7192", "AQAAAAEAACcQAAAAEC4SRbXFEouV0Qomh0MrAuxbhQIQqbRMgs9JL9Js8QHrCTt2S9Q4bBq5fCF+qnmIQA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6da438a4-5fe9-471a-b814-0ac81dd2b89e", "AQAAAAEAACcQAAAAEMXU9JlkyGZEnq9we93YOqe4wiwT4NtAstN6wunHZSA7XC0lDogito75z3SrKQbSQg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2cc171f2-6292-4404-8628-b819ba70adcf", "AQAAAAEAACcQAAAAEKEoekumKs+PHoPB2x6hG10duILk+yO4nSPzIiq2bnyiWA8kh+PiNfPN6zGIUuEF3Q==" });
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
