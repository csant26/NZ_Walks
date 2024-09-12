using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NZWalks_API.Migrations
{
    /// <inheritdoc />
    public partial class mgir : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[] { new Guid("62f4d411-02c8-42f8-a65f-9350017b5984"), "Ack", "Auckland", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fnztraveltips.com%2Fauckland-walks%2F&psig=AOvVaw0_uAXPNhMCy7Vq0Uo31BAx&ust=1726212687422000&source=images&cd=vfe&opi=89978449&ved=0CBIQjRxqFwoTCODw88LxvIgDFQAAAAAdAAAAABAE" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("62f4d411-02c8-42f8-a65f-9350017b5984"));
        }
    }
}
