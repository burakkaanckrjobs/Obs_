using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ObsProject.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hobbys = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "İllers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sehiradi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İllers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "İlcelers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ilceadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sehirid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_İlcelers", x => x.id);
                    table.ForeignKey(
                        name: "FK_İlcelers_İllers_sehirid",
                        column: x => x.sehirid,
                        principalTable: "İllers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Grup = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_İlcelers_CityId",
                        column: x => x.CityId,
                        principalTable: "İlcelers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "StudentHobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    HobbyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentHobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentHobbies_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StudentHobbies_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TeacherStudens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    GuideTeacherId = table.Column<int>(type: "int", nullable: false),
                    ClasssTeacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherStudens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherStudens_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeacherStudens_Teachers_ClasssTeacherId",
                        column: x => x.ClasssTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TeacherStudens_Teachers_GuideTeacherId",
                        column: x => x.GuideTeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_İlcelers_sehirid",
                table: "İlcelers",
                column: "sehirid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHobbies_HobbyId",
                table: "StudentHobbies",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHobbies_StudentId",
                table: "StudentHobbies",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CityId",
                table: "Students",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudens_ClasssTeacherId",
                table: "TeacherStudens",
                column: "ClasssTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudens_GuideTeacherId",
                table: "TeacherStudens",
                column: "GuideTeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherStudens_StudentId",
                table: "TeacherStudens",
                column: "StudentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentHobbies");

            migrationBuilder.DropTable(
                name: "TeacherStudens");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "İlcelers");

            migrationBuilder.DropTable(
                name: "İllers");
        }
    }
}
