using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks_API.Migrations
{
    /// <inheritdoc />
    public partial class seedingdatafordifficultiesandregions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("62f4d411-02c8-42f8-a65f-9350017b5984"));

            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0950b654-f850-419c-92be-8c029862307c"), "Easy" },
                    { new Guid("37338a93-57ff-4e7b-989f-9db710721c4f"), "Hard" },
                    { new Guid("4b0b411f-3bc6-4e3b-a479-a464cb16e5bd"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("14ceba71-4b51-4777-9b17-46602cf66153"), "BOP", "Bay Of Plenty", null },
                    { new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"), "NTL", "Northland", null },
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "STL", "Southland", null },
                    { new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("14ceba71-4b51-4777-9b17-46602cf66153"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("6884f7d7-ad1f-4101-8df3-7a6fa7387d81"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cfa06ed2-bf65-4b65-93ed-c9d286ddb0de"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f7248fc3-2585-4efb-8d1d-1c555f4087f6"));

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[] { new Guid("62f4d411-02c8-42f8-a65f-9350017b5984"), "Ack", "Auckland", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fnztraveltips.com%2Fauckland-walks%2F&psig=AOvVaw0_uAXPNhMCy7Vq0Uo31BAx&ust=1726212687422000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCODw88LxvIgDFQAAAAAdAAAAABAE" });
        }
    }
}
