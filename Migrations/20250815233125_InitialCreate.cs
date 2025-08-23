using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace university_Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trainers_resultID",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Stuts",
                table: "Results");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_resultID",
                table: "Trainers",
                column: "resultID");

            migrationBuilder.CreateIndex(
                name: "IX_Results_Trainee_ID",
                table: "Results",
                column: "Trainee_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Trainers_Trainee_ID",
                table: "Results",
                column: "Trainee_ID",
                principalTable: "Trainers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Trainers_Trainee_ID",
                table: "Results");

            migrationBuilder.DropIndex(
                name: "IX_Trainers_resultID",
                table: "Trainers");

            migrationBuilder.DropIndex(
                name: "IX_Results_Trainee_ID",
                table: "Results");

            migrationBuilder.AddColumn<string>(
                name: "Stuts",
                table: "Results",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_resultID",
                table: "Trainers",
                column: "resultID",
                unique: true,
                filter: "[resultID] IS NOT NULL");
        }
    }
}
