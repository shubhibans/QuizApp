using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuizApp.Migrations.AppDB
{
    public partial class AddedAuditFieldstoModels1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_AppAdmin_UserId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_UserId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "AddingUserId",
                table: "Question",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Question_AddingUserId",
                table: "Question",
                column: "AddingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AppAdmin_AddingUserId",
                table: "Question",
                column: "AddingUserId",
                principalTable: "AppAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_AppAdmin_AddingUserId",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_Question_AddingUserId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "AddingUserId",
                table: "Question");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Question_UserId",
                table: "Question",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AppAdmin_UserId",
                table: "Question",
                column: "UserId",
                principalTable: "AppAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
