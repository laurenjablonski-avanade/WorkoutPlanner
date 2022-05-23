using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkoutPlanner.Migrations
{
    public partial class MigrationToTheExerciseDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkoutPlanner",
                table: "WorkoutPlanner");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "WorkoutPlanner");

            migrationBuilder.RenameTable(
                name: "WorkoutPlanner",
                newName: "Exercises");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Exercises",
                newName: "Exercise");

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoURL",
                table: "Exercises",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExerciseId = table.Column<int>(type: "int", nullable: false),
                    HasCompleted = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "VideoURL",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "WorkoutPlanner");

            migrationBuilder.RenameColumn(
                name: "Exercise",
                table: "WorkoutPlanner",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "WorkoutPlanner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkoutPlanner",
                table: "WorkoutPlanner",
                column: "Id");
        }
    }
}
