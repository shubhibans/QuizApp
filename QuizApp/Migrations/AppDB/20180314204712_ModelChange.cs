using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuizApp.Migrations.AppDB
{
    public partial class ModelChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_AppAdmin_AddedById",
                table: "Question");

            migrationBuilder.AlterColumn<int>(
                name: "AddedById",
                table: "Question",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "AddedById",
                table: "AppAdmin",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "AppAdmin",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_AppAdmin_AddedById",
                table: "AppAdmin",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAdmin_AppUser_AddedById",
                table: "AppAdmin",
                column: "AddedById",
                principalTable: "AppUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AppAdmin_AddedById",
                table: "Question",
                column: "AddedById",
                principalTable: "AppAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAdmin_AppUser_AddedById",
                table: "AppAdmin");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_AppAdmin_AddedById",
                table: "Question");

            migrationBuilder.DropIndex(
                name: "IX_AppAdmin_AddedById",
                table: "AppAdmin");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "AppAdmin");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "AppAdmin");

            migrationBuilder.AlterColumn<int>(
                name: "AddedById",
                table: "Question",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AppAdmin_AddedById",
                table: "Question",
                column: "AddedById",
                principalTable: "AppAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
