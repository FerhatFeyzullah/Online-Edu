using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineEdu.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_Course_register_adding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegister_AspNetUsers_AppUserId",
                table: "CourseRegister");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegister_Courses_CourseId",
                table: "CourseRegister");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseRegister",
                table: "CourseRegister");

            migrationBuilder.RenameTable(
                name: "CourseRegister",
                newName: "CourseRegisters");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegister_CourseId",
                table: "CourseRegisters",
                newName: "IX_CourseRegisters_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegister_AppUserId",
                table: "CourseRegisters",
                newName: "IX_CourseRegisters_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseRegisters",
                table: "CourseRegisters",
                column: "CourseRegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegisters_AspNetUsers_AppUserId",
                table: "CourseRegisters",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegisters_Courses_CourseId",
                table: "CourseRegisters",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegisters_AspNetUsers_AppUserId",
                table: "CourseRegisters");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseRegisters_Courses_CourseId",
                table: "CourseRegisters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseRegisters",
                table: "CourseRegisters");

            migrationBuilder.RenameTable(
                name: "CourseRegisters",
                newName: "CourseRegister");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegisters_CourseId",
                table: "CourseRegister",
                newName: "IX_CourseRegister_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_CourseRegisters_AppUserId",
                table: "CourseRegister",
                newName: "IX_CourseRegister_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseRegister",
                table: "CourseRegister",
                column: "CourseRegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegister_AspNetUsers_AppUserId",
                table: "CourseRegister",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseRegister_Courses_CourseId",
                table: "CourseRegister",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
