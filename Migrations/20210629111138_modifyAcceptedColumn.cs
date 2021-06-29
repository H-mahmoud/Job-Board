using Microsoft.EntityFrameworkCore.Migrations;

namespace Job_Board.Migrations
{
    public partial class modifyAcceptedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Accepted",
                table: "jobs",
                type: "bit",
                nullable: true,
                defaultValueSql: "0",
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "96cb536d-16da-418d-85b4-10de38ee1600");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "153e0939-fcdc-4207-a96d-7105d94aa34b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "3c7eff6f-b0f3-458d-886e-9061e51f45e2");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b2dda1c4-4495-4df1-bf54-d1ddb44e0f41", "AQAAAAEAACcQAAAAEFZXyLNA1Fk00ZwAdjH8P9MwMYBw5Y+LTzpO8D0o0UD64/HKOClHsGmrrMDq7olqMg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Accepted",
                table: "jobs",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true,
                oldDefaultValueSql: "0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "f1a9a4e2-e48b-4a86-affa-24b5e2d32156");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "98c7efe9-303a-468a-a510-0b30f5a77dfd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "9bb62ffb-a18c-4871-b001-c1bdea011977");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8d70a46b-20fa-49ab-aabe-78339c41bc4b", "AQAAAAEAACcQAAAAEE8ehsj8vRtwLkB/to3BmOLbf0FhNfIpCJQAKV3CpESSue/LvQ5/Gkg4rLHFnT6LcA==" });
        }
    }
}
