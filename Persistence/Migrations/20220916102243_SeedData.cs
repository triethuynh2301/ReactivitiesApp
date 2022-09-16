using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("7aee3ae2-310b-44e2-b3ad-23bfa8d4a0b0"), "travel", "London", new DateTime(2023, 4, 16, 5, 22, 42, 982, DateTimeKind.Local).AddTicks(2331), "Activity 2 months ago", "Future Activity 7", "Somewhere on the Thames" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("8bd0a1f8-f0ab-4323-9c57-7b6174fb0683"), "music", "London", new DateTime(2023, 3, 16, 5, 22, 42, 982, DateTimeKind.Local).AddTicks(2309), "Activity 6 months in future", "Future Activity 6", "Roundhouse Camden" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("8ef4aa56-87b1-4dcd-a683-bd933c5082a1"), "drinks", "London", new DateTime(2023, 1, 16, 5, 22, 42, 982, DateTimeKind.Local).AddTicks(2264), "Activity 4 months in future", "Future Activity 4", "Yet another pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("99d8fe9c-94b8-4d80-bbfd-4bccc496d54f"), "film", "London", new DateTime(2023, 5, 16, 5, 22, 42, 982, DateTimeKind.Local).AddTicks(2353), "Activity 8 months in future", "Future Activity 8", "Cinema" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("99df3931-32e9-48bd-9fdd-07afce405b84"), "culture", "Paris", new DateTime(2022, 8, 16, 5, 22, 42, 982, DateTimeKind.Local).AddTicks(2170), "Activity 1 month ago", "Past Activity 2", "Louvre" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("9e902e71-8f19-4993-ba8a-7288559bbf48"), "culture", "London", new DateTime(2022, 10, 16, 5, 22, 42, 982, DateTimeKind.Local).AddTicks(2193), "Activity 1 month in future", "Future Activity 1", "Natural History Museum" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("b2a29d53-b4e3-4598-b3e1-2f410cb54477"), "drinks", "London", new DateTime(2023, 2, 16, 5, 22, 42, 982, DateTimeKind.Local).AddTicks(2286), "Activity 5 months in future", "Future Activity 5", "Just another pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("c79bb016-6d7c-4983-87f7-6c5e5062d9d2"), "music", "London", new DateTime(2022, 11, 16, 5, 22, 42, 982, DateTimeKind.Local).AddTicks(2217), "Activity 2 months in future", "Future Activity 2", "O2 Arena" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("d4917ce1-0cc9-49ec-b7f9-9bace564d130"), "drinks", "London", new DateTime(2022, 7, 16, 5, 22, 42, 982, DateTimeKind.Local).AddTicks(2108), "Activity 2 months ago", "Past Activity 1", "Pub" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("f02d651a-304c-402e-9cd1-ad2c70d7481b"), "drinks", "London", new DateTime(2022, 12, 16, 5, 22, 42, 982, DateTimeKind.Local).AddTicks(2242), "Activity 3 months in future", "Future Activity 3", "Another pub" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("7aee3ae2-310b-44e2-b3ad-23bfa8d4a0b0"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8bd0a1f8-f0ab-4323-9c57-7b6174fb0683"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8ef4aa56-87b1-4dcd-a683-bd933c5082a1"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("99d8fe9c-94b8-4d80-bbfd-4bccc496d54f"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("99df3931-32e9-48bd-9fdd-07afce405b84"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("9e902e71-8f19-4993-ba8a-7288559bbf48"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("b2a29d53-b4e3-4598-b3e1-2f410cb54477"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("c79bb016-6d7c-4983-87f7-6c5e5062d9d2"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("d4917ce1-0cc9-49ec-b7f9-9bace564d130"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("f02d651a-304c-402e-9cd1-ad2c70d7481b"));
        }
    }
}
