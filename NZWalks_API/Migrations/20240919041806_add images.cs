using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks_API.Migrations
{
    /// <inheritdoc />
    public partial class addimages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0950b654-f850-419c-92be-8c029862307c"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("37338a93-57ff-4e7b-989f-9db710721c4f"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("4b0b411f-3bc6-4e3b-a479-a464cb16e5bd"));

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    fileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fileSizeInBytes = table.Column<long>(type: "bigint", nullable: false),
                    filePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("62a8036d-628a-4e80-a761-f8ebd946ea68"), "Medium" },
                    { new Guid("f4786332-349d-4e72-a3bc-950433a404a1"), "Hard" },
                    { new Guid("fd53e928-9668-4aa0-9ff6-c690edb8af98"), "Easy" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("62a8036d-628a-4e80-a761-f8ebd946ea68"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f4786332-349d-4e72-a3bc-950433a404a1"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("fd53e928-9668-4aa0-9ff6-c690edb8af98"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0950b654-f850-419c-92be-8c029862307c"), "Easy" },
                    { new Guid("37338a93-57ff-4e7b-989f-9db710721c4f"), "Hard" },
                    { new Guid("4b0b411f-3bc6-4e3b-a479-a464cb16e5bd"), "Medium" }
                });
        }
    }
}
