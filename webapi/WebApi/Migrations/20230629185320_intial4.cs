using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b1c6e7f5-c3af-49c3-9195-71a30f05378c", "AQAAAAEAACcQAAAAEFi0/9iKA4tYsh+ceISNA5v356NubykQMDYlRIVfDPfs2eir1S6iyQHMdPYnTf+5AA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0110324-8e01-4db3-a9fc-793ce46a7c75", "AQAAAAEAACcQAAAAEPUmSnrKfq1AwaWqcFLhzutf/P3oOsov1QD3x86A19AeR9YUNXa2Jo1wILdOaiHp8Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3881d341-9f95-4bfb-acef-c9c7355ddd68", "AQAAAAEAACcQAAAAEBwjKf/5qbzB4qXm6gJwp1IcsrccDhtnwZF603lfNHVwPeIEFdQz79nuZvVvK8u+lA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
