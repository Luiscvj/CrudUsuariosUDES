using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrudUdes.Persistence.Data.Migrations
{
    /// <inheritdoc />
    public partial class Addingtheseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "document_type",
                columns: new[] { "DocumentTypeId", "type" },
                values: new object[,]
                {
                    { 1, "Cedula" },
                    { 2, "Pasaporte" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "RoleId", "RoleDescription", "RoleName" },
                values: new object[,]
                {
                    { 1, null, "Admin" },
                    { 2, null, "Employee" },
                    { 3, null, "Manager" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "UserId", "DocumentNumber", "DocumentTypeId", "Email", "LastName", "Name", "Password", "UserName" },
                values: new object[] { 1, "1231", 1, "try@try.com", "Villegas", "Jose", "jose2yw&IU", "Jose_" });

            migrationBuilder.InsertData(
                table: "user_roles",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "document_type",
                keyColumn: "DocumentTypeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "RoleId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "user_roles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "roles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "document_type",
                keyColumn: "DocumentTypeId",
                keyValue: 1);
        }
    }
}
