using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace QuizApp.Migrations.AppDB
{
    public partial class InitialQuiz2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "type",
                table: "QuestionType",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "NormalizedType",
                table: "QuestionType",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NormalizedType",
                table: "QuestionType");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "QuestionType",
                newName: "type");
        }
    }
}
