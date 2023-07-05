using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class FirstMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6697a672-aad0-4ad6-9994-4240e359bc70", "AQAAAAEAACcQAAAAEKbN8XTUbu8CG7Q9IliMzqsQ+mbt7y7+QULJX50ns1DGY4XBAh6yvQa4HSrDuDKwjQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9bd8503b-433c-40c7-a667-0b5ee47cd905", "AQAAAAEAACcQAAAAEPxMyFcc8nzdcjhUjc6gCGL5NsEdwhcyy9hnEuK6ptwUcc2bQa7mlJU4Z2znAIw+1g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "53d68d81-4f5c-4a53-a040-4e906b419218", "AQAAAAEAACcQAAAAEJeRqA7TBwHDzHEkVwhirySDZBdIN9QQVYrD35AFU5BYjIeesUTR/3GK5jR0IqJChg==" });
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
