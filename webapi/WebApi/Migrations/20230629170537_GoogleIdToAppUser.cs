using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class GoogleIdToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GoogleId",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "GoogleId", "PasswordHash" },
                values: new object[] { "059e5b83-66a7-4fc7-b393-c64e3b1b0712", null, "AQAAAAEAACcQAAAAEDglqGO7ngRU2g4s+vD47UXO2eDRCYlJckpS8bQdsticsNrDaN2Mn8QXzQeMGCWK9A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "GoogleId", "PasswordHash" },
                values: new object[] { "030d2431-16b3-4619-8728-abb47773b4da", null, "AQAAAAEAACcQAAAAENLesqDm+m/a8NWcBzpLxGUjAU7qmQ20eLMbCF4SsbpSxQYzVvf6Nr1R5xr4VRn4CA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "GoogleId", "PasswordHash" },
                values: new object[] { "cf706946-cdf9-4e08-97cb-3d8ea63d7424", null, "AQAAAAEAACcQAAAAEE6/HvLL88yxgPki95/9twKQzeKKGcDBWs4ti7v0HrtA02YL5oHVJLEiBN5P8CSUUA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GoogleId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d9bc56d0-9687-4cf1-b15b-60c8f523729a", "AQAAAAEAACcQAAAAEK+hxuiNfjLDqh65tvgqz+6g3fDNd1IrRyarEz/CqA9L3gJWNDEHnn8kn7pWqomdDg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a622a475-5e38-429e-a256-515c7da4e706", "AQAAAAEAACcQAAAAEGOC5L4Li+KUAXv4+N5KJkcACUjSMYczZzO3GaNaOxFedFVpGhdcxVEErLP3B6zExQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "fd381442-6b97-499e-aa72-359740237a4c", "AQAAAAEAACcQAAAAEGYcnp9Qp/AsUApJKb8oG2IMKsGqJ7/RAEti/n2Nb8LsmVfcYFYAZt5O88bLHT/O5A==" });
        }
    }
}
