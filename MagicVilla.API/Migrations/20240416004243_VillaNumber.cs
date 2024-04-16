using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MagicVilla.API.Migrations
{
    /// <inheritdoc />
    public partial class VillaNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Regions_Villas_VillaID",
                table: "Regions");

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("081aedcc-dd6b-4514-8bcc-7af4a512bd4c"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("3478aa88-f352-4e21-84cf-e3089bbb78bd"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("40416397-c89b-46b9-bc47-dcc56dddc203"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("914418f9-a4f0-4911-8c9c-8bd72fb5bd83"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("ec77d02a-2ef0-4d58-91d8-7014561e7d98"));

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "VillaNumbers");

            migrationBuilder.RenameIndex(
                name: "IX_Regions_VillaID",
                table: "VillaNumbers",
                newName: "IX_VillaNumbers_VillaID");

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("317301f2-75ee-486a-b221-f346999123e7"), "", new DateTime(2024, 4, 16, 0, 42, 39, 136, DateTimeKind.Local).AddTicks(4994), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600.0, 1100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("380c1ddf-dc74-44be-ba6b-bd658b2b3390"), "", new DateTime(2024, 4, 16, 0, 42, 39, 136, DateTimeKind.Local).AddTicks(4983), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550.0, 900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3a1c112a-e2a1-409f-9658-bcc38ee4ca09"), "", new DateTime(2024, 4, 16, 0, 42, 39, 136, DateTimeKind.Local).AddTicks(4972), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400.0, 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89b34ded-97b1-4529-83fd-257958394709"), "", new DateTime(2024, 4, 16, 0, 42, 39, 136, DateTimeKind.Local).AddTicks(4840), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa3.jpg", "Royal Villa", 4, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("cd13bda8-52d7-4be6-b9e6-104cfe6f943f"), "", new DateTime(2024, 4, 16, 0, 42, 39, 136, DateTimeKind.Local).AddTicks(4957), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers",
                column: "VillaID",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VillaNumbers_Villas_VillaID",
                table: "VillaNumbers");

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("317301f2-75ee-486a-b221-f346999123e7"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("380c1ddf-dc74-44be-ba6b-bd658b2b3390"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("3a1c112a-e2a1-409f-9658-bcc38ee4ca09"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("89b34ded-97b1-4529-83fd-257958394709"));

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: new Guid("cd13bda8-52d7-4be6-b9e6-104cfe6f943f"));

            migrationBuilder.RenameTable(
                name: "VillaNumbers",
                newName: "Regions");

            migrationBuilder.RenameIndex(
                name: "IX_VillaNumbers_VillaID",
                table: "Regions",
                newName: "IX_Regions_VillaID");

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("081aedcc-dd6b-4514-8bcc-7af4a512bd4c"), "", new DateTime(2024, 4, 15, 17, 49, 49, 399, DateTimeKind.Local).AddTicks(5866), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa5.jpg", "Diamond Villa", 4, 550.0, 900, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3478aa88-f352-4e21-84cf-e3089bbb78bd"), "", new DateTime(2024, 4, 15, 17, 49, 49, 399, DateTimeKind.Local).AddTicks(5806), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa3.jpg", "Royal Villa", 4, 200.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("40416397-c89b-46b9-bc47-dcc56dddc203"), "", new DateTime(2024, 4, 15, 17, 49, 49, 399, DateTimeKind.Local).AddTicks(5837), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa1.jpg", "Premium Pool Villa", 4, 300.0, 550, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("914418f9-a4f0-4911-8c9c-8bd72fb5bd83"), "", new DateTime(2024, 4, 15, 17, 49, 49, 399, DateTimeKind.Local).AddTicks(5869), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa2.jpg", "Diamond Pool Villa", 4, 600.0, 1100, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("ec77d02a-2ef0-4d58-91d8-7014561e7d98"), "", new DateTime(2024, 4, 15, 17, 49, 49, 399, DateTimeKind.Local).AddTicks(5862), "Fusce 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmastery.com/bluevillaimages/villa4.jpg", "Luxury Pool Villa", 4, 400.0, 750, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Regions_Villas_VillaID",
                table: "Regions",
                column: "VillaID",
                principalTable: "Villas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
