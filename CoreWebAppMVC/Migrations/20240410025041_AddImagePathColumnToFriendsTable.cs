﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreWebAppMVC.Migrations
{
    /// <inheritdoc />
    public partial class AddImagePathColumnToFriendsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Friends",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Friends",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/f/2fabe02d-b3de-4453-a877-3e57a9266b30/deyynsc-7673267a-f883-4f9f-a2e3-fd4733c9f30c.png/v1/fill/w_730,h_1095,q_70,strp/nezuko_s_demon_form_by_oddityillustrations_deyynsc-pre.jpg?token=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiJ1cm46YXBwOjdlMGQxODg5ODIyNjQzNzNhNWYwZDQxNWVhMGQyNmUwIiwiaXNzIjoidXJuOmFwcDo3ZTBkMTg4OTgyMjY0MzczYTVmMGQ0MTVlYTBkMjZlMCIsIm9iaiI6W1t7ImhlaWdodCI6Ijw9MzYwMCIsInBhdGgiOiJcL2ZcLzJmYWJlMDJkLWIzZGUtNDQ1My1hODc3LTNlNTdhOTI2NmIzMFwvZGV5eW5zYy03NjczMjY3YS1mODgzLTRmOWYtYTJlMy1mZDQ3MzNjOWYzMGMucG5nIiwid2lkdGgiOiI8PTI0MDAifV1dLCJhdWQiOlsidXJuOnNlcnZpY2U6aW1hZ2Uub3BlcmF0aW9ucyJdfQ.nsUBfTt3zLKrf_1ekFBFgYiLTh5svH0AZPw9TZQVop4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Friends");
        }
    }
}
