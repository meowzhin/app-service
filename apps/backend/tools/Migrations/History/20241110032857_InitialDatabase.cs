using System;
using System.Collections.Generic;
using FwksLabs.ResumeService.Core.OwnedTypes;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FwksLabs.Migrations.History
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "App");

            migrationBuilder.CreateTable(
                name: "Resumes",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<NameOwnedType>(type: "jsonb", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<LocationOwnedType>(type: "jsonb", nullable: true),
                    ContactInformation = table.Column<ContactInformationOwnedType>(type: "jsonb", nullable: true),
                    Socials = table.Column<ICollection<SocialOwnedType>>(type: "jsonb", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resumes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AcademicRecords",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResumeId = table.Column<int>(type: "integer", nullable: false),
                    Course = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: false),
                    School = table.Column<string>(type: "text", nullable: false),
                    DateInterval = table.Column<DateIntervalOwnedType>(type: "jsonb", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ReferenceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "App",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competencies",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResumeId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: true),
                    ReferenceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "App",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmploymentHistory",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ResumeId = table.Column<int>(type: "integer", nullable: false),
                    Company = table.Column<string>(type: "text", nullable: false),
                    Position = table.Column<string>(type: "text", nullable: false),
                    DateInterval = table.Column<DateIntervalOwnedType>(type: "jsonb", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ReferenceId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resumes_ResumeId",
                        column: x => x.ResumeId,
                        principalSchema: "App",
                        principalTable: "Resumes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicRecords_ResumeId",
                schema: "App",
                table: "AcademicRecords",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_UK_AcademicRecords",
                schema: "App",
                table: "AcademicRecords",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competencies_ResumeId",
                schema: "App",
                table: "Competencies",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_UK_Competencies",
                schema: "App",
                table: "Competencies",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentHistory_ResumeId",
                schema: "App",
                table: "EmploymentHistory",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_UK_EmploymentHistory",
                schema: "App",
                table: "EmploymentHistory",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_Slug",
                schema: "App",
                table: "Resumes",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UK_Resumes",
                schema: "App",
                table: "Resumes",
                column: "ReferenceId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademicRecords",
                schema: "App");

            migrationBuilder.DropTable(
                name: "Competencies",
                schema: "App");

            migrationBuilder.DropTable(
                name: "EmploymentHistory",
                schema: "App");

            migrationBuilder.DropTable(
                name: "Resumes",
                schema: "App");
        }
    }
}
