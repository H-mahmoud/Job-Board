using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Job_Board.Migrations
{
    public partial class ChangeDateType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3a2f71a-cd52-4c43-8710-c118ccda0c33");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f79eff17-f136-4470-b2fe-136b5a9fe5b9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "0941ba20-4d90-4cc5-a428-3f21d2e03ec9");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "0f3a5c78-b12c-45a4-ab26-86cd69c27e3a");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: "5c6e428c-3613-436a-afe5-4367ccaebcae");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PublishedAt",
                table: "jobs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getutcdate()",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "PublishedAt",
                table: "jobs",
                type: "nvarchar(max)",
                nullable: true,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getutcdate()");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f79eff17-f136-4470-b2fe-136b5a9fe5b9", "d6d55a1b-490e-49c1-bd78-79fcfcc2aa13", "Recruiter", "RECRUITER" },
                    { "e3a2f71a-cd52-4c43-8710-c118ccda0c33", "902ce14d-8634-4cea-9fad-12b753eb0fc0", "Developer", "DEVELOPER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "0f3a5c78-b12c-45a4-ab26-86cd69c27e3a", "Android Developer" },
                    { "0941ba20-4d90-4cc5-a428-3f21d2e03ec9", "IOS Developer" },
                    { "5c6e428c-3613-436a-afe5-4367ccaebcae", "Web Developer" }
                });
        }
    }
}
