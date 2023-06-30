using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class dbsetsforcommits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commit_Author_authorname",
                table: "Commit");

            migrationBuilder.DropForeignKey(
                name: "FK_Commit_Committer_committername",
                table: "Commit");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCommits_Author_authorname",
                table: "ListOfCommits");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCommits_Commit_commitsha",
                table: "ListOfCommits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commit",
                table: "Commit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Author",
                table: "Author");

            migrationBuilder.RenameTable(
                name: "Commit",
                newName: "Commits");

            migrationBuilder.RenameTable(
                name: "Author",
                newName: "Authors");

            migrationBuilder.RenameIndex(
                name: "IX_Commit_committername",
                table: "Commits",
                newName: "IX_Commits_committername");

            migrationBuilder.RenameIndex(
                name: "IX_Commit_authorname",
                table: "Commits",
                newName: "IX_Commits_authorname");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commits",
                table: "Commits",
                column: "sha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Authors",
                table: "Authors",
                column: "name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d4c15749-89bb-4e59-b3ce-f682ab68e54a", "AQAAAAEAACcQAAAAEPUYahMEWRpDxQSGtxibQvNY7SOstOwlI2i9V1iqNGhK+OI69GUEJLvXOThS7Q8geQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "485909fa-b0de-40b1-9549-754c6cd32bc4", "AQAAAAEAACcQAAAAEK2Q7VeqhMtvCyAF/cbttgcBTgC6BISE9r2oCwcbUu///CRzX7Fu7n42xuCidifgsQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "049be1c6-fa5e-4553-9d4a-2b059845bba7", "AQAAAAEAACcQAAAAEB1rZ+aGu2kmV14Yq2GJhKKQ+1tMqOoudpEJp6RZKN93c7wjkxnj3RtXjDfMTZvFmQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Commits_Authors_authorname",
                table: "Commits",
                column: "authorname",
                principalTable: "Authors",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_Commits_Committer_committername",
                table: "Commits",
                column: "committername",
                principalTable: "Committer",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCommits_Authors_authorname",
                table: "ListOfCommits",
                column: "authorname",
                principalTable: "Authors",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCommits_Commits_commitsha",
                table: "ListOfCommits",
                column: "commitsha",
                principalTable: "Commits",
                principalColumn: "sha");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commits_Authors_authorname",
                table: "Commits");

            migrationBuilder.DropForeignKey(
                name: "FK_Commits_Committer_committername",
                table: "Commits");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCommits_Authors_authorname",
                table: "ListOfCommits");

            migrationBuilder.DropForeignKey(
                name: "FK_ListOfCommits_Commits_commitsha",
                table: "ListOfCommits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commits",
                table: "Commits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Authors",
                table: "Authors");

            migrationBuilder.RenameTable(
                name: "Commits",
                newName: "Commit");

            migrationBuilder.RenameTable(
                name: "Authors",
                newName: "Author");

            migrationBuilder.RenameIndex(
                name: "IX_Commits_committername",
                table: "Commit",
                newName: "IX_Commit_committername");

            migrationBuilder.RenameIndex(
                name: "IX_Commits_authorname",
                table: "Commit",
                newName: "IX_Commit_authorname");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commit",
                table: "Commit",
                column: "sha");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Author",
                table: "Author",
                column: "name");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8ec7dcf9-521d-402d-a82b-310b9665ba36", "AQAAAAEAACcQAAAAEHZuF7hL6f0M1DI1zkTxEQo2elF/PsTUEAhEcN8FIvOgQFTAJHX3bgXVEem79ncx8g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "80e8b0ab-cccf-4b63-a350-436d433944ec", "AQAAAAEAACcQAAAAECkyJaDeTNh4EgNzwI0w9rtk0wc+XC+y0vt/HMC1N6pWGbkr9zhDOxrBzW2Oy3o59g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2a70b5fa-525a-42e9-a1a6-5d9f70f9e5d3", "AQAAAAEAACcQAAAAEPuP53aG8IFrbO+v1nWqkv/xhQuNXiOq7UWdg9bu9EMWTRn9J7QRrrmVmsNtS+PPWA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Commit_Author_authorname",
                table: "Commit",
                column: "authorname",
                principalTable: "Author",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_Commit_Committer_committername",
                table: "Commit",
                column: "committername",
                principalTable: "Committer",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCommits_Author_authorname",
                table: "ListOfCommits",
                column: "authorname",
                principalTable: "Author",
                principalColumn: "name");

            migrationBuilder.AddForeignKey(
                name: "FK_ListOfCommits_Commit_commitsha",
                table: "ListOfCommits",
                column: "commitsha",
                principalTable: "Commit",
                principalColumn: "sha");
        }
    }
}
