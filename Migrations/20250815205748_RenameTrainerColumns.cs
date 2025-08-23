using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace university_Project.Migrations
{
    /// <inheritdoc />
    public partial class RenameTrainerColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manager = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Degree = table.Column<double>(type: "float", nullable: false),
                    Min_Degree = table.Column<double>(type: "float", nullable: false),
                    Depart_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Courses_Departments_Depart_ID",
                        column: x => x.Depart_ID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Instrutors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image_URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Depart_ID = table.Column<int>(type: "int", nullable: false),
                    CRS_ID = table.Column<int>(type: "int", nullable: false),
                    Cls_DepartmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrutors", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Instrutors_Courses_CRS_ID",
                        column: x => x.CRS_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instrutors_Departments_Cls_DepartmentID",
                        column: x => x.Cls_DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Instrutors_Departments_Depart_ID",
                        column: x => x.Depart_ID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Degree = table.Column<double>(type: "float", nullable: false),
                    Crs_ID = table.Column<int>(type: "int", nullable: false),
                    Trainee_ID = table.Column<int>(type: "int", nullable: false),
                    Stuts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cls_CourseID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Results_Courses_Cls_CourseID",
                        column: x => x.Cls_CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Results_Courses_Crs_ID",
                        column: x => x.Crs_ID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    resultID = table.Column<int>(type: "int", nullable: true),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: false),
                    Cls_DepartmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Trainers_Courses_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainers_Departments_Cls_DepartmentID",
                        column: x => x.Cls_DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Trainers_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Trainers_Results_resultID",
                        column: x => x.resultID,
                        principalTable: "Results",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Depart_ID",
                table: "Courses",
                column: "Depart_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Instrutors_Cls_DepartmentID",
                table: "Instrutors",
                column: "Cls_DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Instrutors_CRS_ID",
                table: "Instrutors",
                column: "CRS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Instrutors_Depart_ID",
                table: "Instrutors",
                column: "Depart_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_Cls_CourseID",
                table: "Results",
                column: "Cls_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_Crs_ID",
                table: "Results",
                column: "Crs_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_Cls_DepartmentID",
                table: "Trainers",
                column: "Cls_DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_CourseID",
                table: "Trainers",
                column: "CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_DepartmentID",
                table: "Trainers",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_resultID",
                table: "Trainers",
                column: "resultID",
                unique: true,
                filter: "[resultID] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instrutors");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
