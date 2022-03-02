﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebCv.Api.Data;

namespace WebCv.Api.Data.Migrations
{
    [DbContext(typeof(WebCvContext))]
    [Migration("20220302230136_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("WebCv.Api.Data.Entities.Knowledge", b =>
                {
                    b.Property<Guid>("KnowledgeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("knowledge_id");

                    b.Property<string>("KnowledgeName")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("knowledge_name");

                    b.Property<byte>("Rating")
                        .HasColumnType("smallint")
                        .HasColumnName("rating");

                    b.HasKey("KnowledgeId")
                        .HasName("pk_knowledges");

                    b.ToTable("knowledges");
                });

            modelBuilder.Entity("WebCv.Api.Data.Entities.PersonalInformation", b =>
                {
                    b.Property<int>("PersonalInformationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("personal_information_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("BirthDay")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("birth_day");

                    b.Property<string>("BirthTown")
                        .HasColumnType("text")
                        .HasColumnName("birth_town");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("last_name");

                    b.Property<string>("LinkedInUrl")
                        .HasColumnType("text")
                        .HasColumnName("linked_in_url");

                    b.Property<string>("XingUrl")
                        .HasColumnType("text")
                        .HasColumnName("xing_url");

                    b.HasKey("PersonalInformationId")
                        .HasName("pk_personal_information");

                    b.ToTable("personal_information");
                });

            modelBuilder.Entity("WebCv.Api.Data.Entities.Project", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("project_id");

                    b.Property<string>("ProjectName")
                        .HasColumnType("text")
                        .HasColumnName("project_name");

                    b.Property<Guid?>("ResumeLineId")
                        .HasColumnType("uuid")
                        .HasColumnName("resume_line_id");

                    b.Property<string[]>("UsedTechnologies")
                        .HasColumnType("text[]")
                        .HasColumnName("used_technologies");

                    b.HasKey("ProjectId")
                        .HasName("pk_projects");

                    b.HasIndex("ResumeLineId")
                        .HasDatabaseName("ix_projects_resume_line_id");

                    b.ToTable("projects");
                });

            modelBuilder.Entity("WebCv.Api.Data.Entities.ResumeLine", b =>
                {
                    b.Property<Guid>("ResumeLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("resume_line_id");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<DateTime?>("End")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("end");

                    b.Property<string>("Header")
                        .HasColumnType("text")
                        .HasColumnName("header");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("start");

                    b.HasKey("ResumeLineId")
                        .HasName("pk_resume_lines");

                    b.ToTable("resume_lines");
                });

            modelBuilder.Entity("WebCv.Api.Data.Entities.Project", b =>
                {
                    b.HasOne("WebCv.Api.Data.Entities.ResumeLine", null)
                        .WithMany("Projects")
                        .HasForeignKey("ResumeLineId")
                        .HasConstraintName("fk_projects_resume_lines_resume_line_id");
                });

            modelBuilder.Entity("WebCv.Api.Data.Entities.ResumeLine", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
