using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class SeedFriendsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Friends",
                columns: new[] { "Id", "Email", "Name", "Skill" },
                values: new object[] { 1, "test@test.com.ar", "Test", 2 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
