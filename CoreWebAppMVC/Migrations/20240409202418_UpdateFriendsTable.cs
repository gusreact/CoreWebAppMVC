﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFriendsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Test2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Test");
        }
    }
}
