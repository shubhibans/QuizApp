using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuizApp.Migrations
{
    public partial class addedCompany1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_AspNetUsers_IdentityId",
                table: "Admins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.RenameTable(
                name: "Admins",
                newName: "AppAdmins");

            migrationBuilder.RenameIndex(
                name: "IX_Admins_IdentityId",
                table: "AppAdmins",
                newName: "IX_AppAdmins_IdentityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppAdmins",
                table: "AppAdmins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppAdmins_AspNetUsers_IdentityId",
                table: "AppAdmins",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppAdmins_AspNetUsers_IdentityId",
                table: "AppAdmins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppAdmins",
                table: "AppAdmins");

            migrationBuilder.RenameTable(
                name: "AppAdmins",
                newName: "Admins");

            migrationBuilder.RenameIndex(
                name: "IX_AppAdmins_IdentityId",
                table: "Admins",
                newName: "IX_Admins_IdentityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_AspNetUsers_IdentityId",
                table: "Admins",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
