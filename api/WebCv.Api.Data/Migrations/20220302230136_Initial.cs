using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace WebCv.Api.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "knowledges",
                columns: table => new
                {
                    knowledge_id = table.Column<Guid>(type: "uuid", nullable: false),
                    knowledge_name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    rating = table.Column<byte>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_knowledges", x => x.knowledge_id);
                });

            migrationBuilder.CreateTable(
                name: "personal_information",
                columns: table => new
                {
                    personal_information_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    birth_day = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    birth_town = table.Column<string>(type: "text", nullable: true),
                    linked_in_url = table.Column<string>(type: "text", nullable: true),
                    xing_url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personal_information", x => x.personal_information_id);
                });

            migrationBuilder.CreateTable(
                name: "resume_lines",
                columns: table => new
                {
                    resume_line_id = table.Column<Guid>(type: "uuid", nullable: false),
                    start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    end = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    header = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_resume_lines", x => x.resume_line_id);
                });

            migrationBuilder.CreateTable(
                name: "projects",
                columns: table => new
                {
                    project_id = table.Column<Guid>(type: "uuid", nullable: false),
                    project_name = table.Column<string>(type: "text", nullable: true),
                    used_technologies = table.Column<string[]>(type: "text[]", nullable: true),
                    resume_line_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projects", x => x.project_id);
                    table.ForeignKey(
                        name: "fk_projects_resume_lines_resume_line_id",
                        column: x => x.resume_line_id,
                        principalTable: "resume_lines",
                        principalColumn: "resume_line_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_projects_resume_line_id",
                table: "projects",
                column: "resume_line_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "knowledges");

            migrationBuilder.DropTable(
                name: "personal_information");

            migrationBuilder.DropTable(
                name: "projects");

            migrationBuilder.DropTable(
                name: "resume_lines");
        }
    }
}
