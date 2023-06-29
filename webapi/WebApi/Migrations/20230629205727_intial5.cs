using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class intial5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
