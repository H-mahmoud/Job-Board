using Microsoft.EntityFrameworkCore.Migrations;

namespace Job_Board.Migrations
{
    public partial class removeAcceptedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Accepted",
                table: "jobs",
                newName: "IsAccepted");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1",
                column: "ConcurrencyStamp",
                value: "37f88515-ea21-4516-8906-66ddfcc8fdcb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2",
                column: "ConcurrencyStamp",
                value: "9b0daaf1-a429-4d7d-b8b8-1a3fd5d28137");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3",
                column: "ConcurrencyStamp",
                value: "2c0c80d8-7cc9-41ab-9b7e-9688e07775e5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "085b75cc-e227-41eb-aa45-b6720fc95557", "AQAAAAEAACcQAAAAENKP0tNNMym331aL2dSNkW3ghHdZB0khjIeTVraXw+IgRCn1z8GGL8rf3nH25Dk1Rw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsAccepted",
                table: "jobs",
                newName: "Accepted");

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
    }
}
