using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectColectiv.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Group_Schedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassScheduleGroup",
                columns: table => new
                {
                    ClassSchedulesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GroupsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassScheduleGroup", x => new { x.ClassSchedulesId, x.GroupsId });
                    table.ForeignKey(
                        name: "FK_ClassScheduleGroup_ClassSchedules_ClassSchedulesId",
                        column: x => x.ClassSchedulesId,
                        principalTable: "ClassSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassScheduleGroup_Groups_GroupsId",
                        column: x => x.GroupsId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassScheduleGroup_GroupsId",
                table: "ClassScheduleGroup",
                column: "GroupsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassScheduleGroup");

            migrationBuilder.DropTable(
                name: "Groups");
        }
    }
}
