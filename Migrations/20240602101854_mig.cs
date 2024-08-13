using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Kyzmav2.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "groups",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NameGroup = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groups", x => x.GroupId);
                });

            migrationBuilder.CreateTable(
                name: "notetypes",
                columns: table => new
                {
                    NotesTypeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NoteTypeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notetypes", x => x.NotesTypeId);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "userss",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Patronymic = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DOB = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    GroupId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userss", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_userss_groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "groups",
                        principalColumn: "GroupId");
                    table.ForeignKey(
                        name: "FK_userss_roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "notes",
                columns: table => new
                {
                    NoteId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NoteText = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    NoteDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    NotesTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notes", x => x.NoteId);
                    table.ForeignKey(
                        name: "FK_notes_notetypes_NotesTypeId",
                        column: x => x.NotesTypeId,
                        principalTable: "notetypes",
                        principalColumn: "NotesTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_notes_userss_UserId",
                        column: x => x.UserId,
                        principalTable: "userss",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "working_plans",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlanTitle = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PlanDescription = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    WayOfFile = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_working_plans", x => x.PlanId);
                    table.ForeignKey(
                        name: "FK_working_plans_userss_UserId",
                        column: x => x.UserId,
                        principalTable: "userss",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "homeworks",
                columns: table => new
                {
                    HomeworkId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DeadlineDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HomeworkDescription = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    PlanId = table.Column<int>(type: "integer", nullable: false),
                    WayHomework = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    StatusHomework = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_homeworks", x => x.HomeworkId);
                    table.ForeignKey(
                        name: "FK_homeworks_working_plans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "working_plans",
                        principalColumn: "PlanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "comment_teachers",
                columns: table => new
                {
                    CommentTId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeacherComment = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    HomeworkId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comment_teachers", x => x.CommentTId);
                    table.ForeignKey(
                        name: "FK_comment_teachers_homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "homeworks",
                        principalColumn: "HomeworkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "commentstudents",
                columns: table => new
                {
                    CommentSId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StudentComment = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    HomeworkId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commentstudents", x => x.CommentSId);
                    table.ForeignKey(
                        name: "FK_commentstudents_homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "homeworks",
                        principalColumn: "HomeworkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dates_of_dzs",
                columns: table => new
                {
                    DatezdId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DzDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    HomeworkId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dates_of_dzs", x => x.DatezdId);
                    table.ForeignKey(
                        name: "FK_dates_of_dzs_homeworks_HomeworkId",
                        column: x => x.HomeworkId,
                        principalTable: "homeworks",
                        principalColumn: "HomeworkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "notetypes",
                columns: new[] { "NotesTypeId", "NoteTypeName" },
                values: new object[,]
                {
                    { 1, "First" },
                    { 2, "Second" },
                    { 3, "Third" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Учитель" },
                    { 2, "Студенет" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_comment_teachers_HomeworkId",
                table: "comment_teachers",
                column: "HomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_commentstudents_HomeworkId",
                table: "commentstudents",
                column: "HomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_dates_of_dzs_HomeworkId",
                table: "dates_of_dzs",
                column: "HomeworkId");

            migrationBuilder.CreateIndex(
                name: "IX_homeworks_PlanId",
                table: "homeworks",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_notes_NotesTypeId",
                table: "notes",
                column: "NotesTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_notes_UserId",
                table: "notes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_userss_GroupId",
                table: "userss",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_userss_RoleId",
                table: "userss",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_working_plans_UserId",
                table: "working_plans",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comment_teachers");

            migrationBuilder.DropTable(
                name: "commentstudents");

            migrationBuilder.DropTable(
                name: "dates_of_dzs");

            migrationBuilder.DropTable(
                name: "notes");

            migrationBuilder.DropTable(
                name: "homeworks");

            migrationBuilder.DropTable(
                name: "notetypes");

            migrationBuilder.DropTable(
                name: "working_plans");

            migrationBuilder.DropTable(
                name: "userss");

            migrationBuilder.DropTable(
                name: "groups");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
