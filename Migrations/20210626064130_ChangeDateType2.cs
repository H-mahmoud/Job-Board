using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Job_Board.Migrations
{
    public partial class ChangeDateType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "492306bc-9c7c-4ab8-94ad-dd2f45cff131");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53b79884-fdd3-4e88-8320-592b8e9f20b3");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "17686786-f8b8-49b2-9697-8629f7cbdcef");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "3945b6da-c47a-4b84-8c0d-52c16af361ca");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "702dcc24-5c8f-4582-b14e-16fb6a614488");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedAt",
                table: "jobs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3b1f51f3-e9a5-4b43-9587-a18c9d06b8e7", "d51b014b-8c1f-4b9e-a5ce-7e6b972d0337", "Recruiter", "RECRUITER" },
                    { "e5f23846-0071-4c87-a24c-963f9d13633a", "8a30c598-b347-41de-b5b6-51379cfc0855", "Developer", "DEVELOPER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "eab70a9c-894a-47fc-adc3-8781e56cb7b0", "Android Developer" },
                    { "6f3b9e5c-617b-4e5f-a4c7-c054d71592b6", "IOS Developer" },
                    { "48a99845-bdfb-43ec-bb4d-90bb6800ea71", "Web Developer" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3b1f51f3-e9a5-4b43-9587-a18c9d06b8e7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e5f23846-0071-4c87-a24c-963f9d13633a");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "48a99845-bdfb-43ec-bb4d-90bb6800ea71");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "6f3b9e5c-617b-4e5f-a4c7-c054d71592b6");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "eab70a9c-894a-47fc-adc3-8781e56cb7b0");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedAt",
                table: "jobs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "492306bc-9c7c-4ab8-94ad-dd2f45cff131", "752a2907-92d6-4fe3-82e1-3949e5d4bb44", "Recruiter", "RECRUITER" },
                    { "53b79884-fdd3-4e88-8320-592b8e9f20b3", "0dd0db0f-9bcb-447c-87eb-22e702d71c8c", "Developer", "DEVELOPER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "17686786-f8b8-49b2-9697-8629f7cbdcef", "Android Developer" },
                    { "3945b6da-c47a-4b84-8c0d-52c16af361ca", "IOS Developer" },
                    { "702dcc24-5c8f-4582-b14e-16fb6a614488", "Web Developer" }
                });
        }
    }
}
