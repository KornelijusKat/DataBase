using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class _29timeTheCharm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Lectures_LectureId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_LectureId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "LectureId",
                table: "Students");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LectureId",
                table: "Students",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_LectureId",
                table: "Students",
                column: "LectureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Lectures_LectureId",
                table: "Students",
                column: "LectureId",
                principalTable: "Lectures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
