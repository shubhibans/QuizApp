using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuizApp.Migrations
{
    public partial class AddedAuditFieldstoModels4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "Interviewees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AddedId",
                table: "Interviewees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "AddedById",
                table: "AppAdmins",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDate",
                table: "AppAdmins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Interviewees_AddedId",
                table: "Interviewees",
                column: "AddedId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAdmins_AddedById",
                table: "AppAdmins",
                column: "AddedById");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAdmins_AspNetUsers_AddedById",
                table: "AppAdmins",
                column: "AddedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Interviewees_AspNetUsers_AddedId",
                table: "Interviewees",
                column: "AddedId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAdmins_AspNetUsers_AddedById",
                table: "AppAdmins");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviewees_AspNetUsers_AddedId",
                table: "Interviewees");

            migrationBuilder.DropIndex(
                name: "IX_Interviewees_AddedId",
                table: "Interviewees");

            migrationBuilder.DropIndex(
                name: "IX_AppAdmins_AddedById",
                table: "AppAdmins");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "Interviewees");

            migrationBuilder.DropColumn(
                name: "AddedId",
                table: "Interviewees");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AddedById",
                table: "AppAdmins");

            migrationBuilder.DropColumn(
                name: "AddedDate",
                table: "AppAdmins");
        }
    }
}
