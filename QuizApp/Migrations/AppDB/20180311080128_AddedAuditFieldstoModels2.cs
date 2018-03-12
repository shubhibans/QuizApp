using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuizApp.Migrations.AppDB
{
    public partial class AddedAuditFieldstoModels2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_AppAdmin_AddingUserId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "AppAdmin");

            migrationBuilder.DropTable(
                name: "AppUser");

            migrationBuilder.DropIndex(
                name: "IX_Question_AddingUserId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "AddingUserId",
                table: "Question");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddingUserId",
                table: "Question",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AppUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    AddedDate = table.Column<DateTime>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppAdmin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Company = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    IdentityId = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppAdmin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AppAdmin_AppUser_IdentityId",
                        column: x => x.IdentityId,
                        principalTable: "AppUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_AddingUserId",
                table: "Question",
                column: "AddingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AppAdmin_IdentityId",
                table: "AppAdmin",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_AppAdmin_AddingUserId",
                table: "Question",
                column: "AddingUserId",
                principalTable: "AppAdmin",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
