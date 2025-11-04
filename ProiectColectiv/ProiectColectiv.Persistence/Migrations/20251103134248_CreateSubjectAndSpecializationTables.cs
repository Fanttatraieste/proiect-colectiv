using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectColectiv.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateSubjectAndSpecializationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpecializationSubject",
                columns: table => new
                {
                    SpecializationsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationSubject", x => new { x.SpecializationsId, x.SubjectsId });
                    table.ForeignKey(
                        name: "FK_SpecializationSubject_Specialization_SpecializationsId",
                        column: x => x.SpecializationsId,
                        principalTable: "Specialization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecializationSubject_Subject_SubjectsId",
                        column: x => x.SubjectsId,
                        principalTable: "Subject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpecializationSubject_SubjectsId",
                table: "SpecializationSubject",
                column: "SubjectsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpecializationSubject");

            migrationBuilder.DropTable(
                name: "Subject");
        }
    }
}
