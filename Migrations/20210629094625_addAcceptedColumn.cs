using Microsoft.EntityFrameworkCore.Migrations;

namespace Job_Board.Migrations
{
    public partial class addAcceptedColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "jobs",
                type: "bit",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "f1a9a4e2-e48b-4a86-affa-24b5e2d32156", "Admin", "ADMIN" },
                    { "2", "98c7efe9-303a-468a-a510-0b30f5a77dfd", "Recruiter", "RECRUITER" },
                    { "3", "9bb62ffb-a18c-4871-b001-c1bdea011977", "Developer", "DEVELOPER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "JobTitle", "LastName", "LinkedInUrl", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "8d70a46b-20fa-49ab-aabe-78339c41bc4b", "UserModel", "admin@jobboard.com", true, "Hassan", null, "Admin", null, false, null, null, null, "AQAAAAEAACcQAAAAEE8ehsj8vRtwLkB/to3BmOLbf0FhNfIpCJQAKV3CpESSue/LvQ5/Gkg4rLHFnT6LcA==", null, false, "", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "1" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "jobs");

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
    }
}
