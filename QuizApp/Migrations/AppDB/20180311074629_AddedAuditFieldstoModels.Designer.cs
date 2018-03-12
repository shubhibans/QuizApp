﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using QuizApp.Persistence;
using System;

namespace QuizApp.Migrations.AppDB
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20180311074629_AddedAuditFieldstoModels")]
    partial class AddedAuditFieldstoModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QuizApp.Model.AppAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("Gender");

                    b.Property<string>("IdentityId");

                    b.Property<string>("Locale");

                    b.Property<string>("Location");

                    b.HasKey("Id");

                    b.HasIndex("IdentityId");

                    b.ToTable("AppAdmin");
                });

            modelBuilder.Entity("QuizApp.Model.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("AppUser");
                });

            modelBuilder.Entity("QuizApp.Model.Difficulty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Difficulty");
                });

            modelBuilder.Entity("QuizApp.Model.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body")
                        .IsRequired();

                    b.Property<bool>("IsAnswer");

                    b.Property<string>("QuestionId")
                        .IsRequired();

                    b.Property<bool>("Selected");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Option");
                });

            modelBuilder.Entity("QuizApp.Model.Question", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(255);

                    b.Property<DateTime>("AddedDate");

                    b.Property<bool>("Answered");

                    b.Property<int>("DifficultyId");

                    b.Property<int>("QuestionTypeId");

                    b.Property<string>("Question_txt")
                        .IsRequired();

                    b.Property<int?>("QuizId");

                    b.Property<int>("SubjectAreaId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("DifficultyId");

                    b.HasIndex("QuestionTypeId");

                    b.HasIndex("QuizId");

                    b.HasIndex("SubjectAreaId");

                    b.HasIndex("UserId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("QuizApp.Model.QuestionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("NormalizedType")
                        .HasMaxLength(255);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("QuestionType");
                });

            modelBuilder.Entity("QuizApp.Model.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("Quizzes");
                });

            modelBuilder.Entity("QuizApp.Model.SubjectArea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Area")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("SubArea")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("SubjectArea");
                });

            modelBuilder.Entity("QuizApp.Model.AppAdmin", b =>
                {
                    b.HasOne("QuizApp.Model.AppUser", "Identity")
                        .WithMany()
                        .HasForeignKey("IdentityId");
                });

            modelBuilder.Entity("QuizApp.Model.Option", b =>
                {
                    b.HasOne("QuizApp.Model.Question", "Question")
                        .WithMany("Options")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("QuizApp.Model.Question", b =>
                {
                    b.HasOne("QuizApp.Model.Difficulty", "Difficulty")
                        .WithMany()
                        .HasForeignKey("DifficultyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuizApp.Model.QuestionType", "QuestionType")
                        .WithMany()
                        .HasForeignKey("QuestionTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuizApp.Model.Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId");

                    b.HasOne("QuizApp.Model.SubjectArea", "SubjectArea")
                        .WithMany()
                        .HasForeignKey("SubjectAreaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("QuizApp.Model.AppAdmin", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
