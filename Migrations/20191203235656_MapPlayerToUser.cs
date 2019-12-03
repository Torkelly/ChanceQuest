using Microsoft.EntityFrameworkCore.Migrations;

namespace ChanceQuest.Migrations
{
    public partial class MapPlayerToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavorableStatId",
                table: "Quests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FavorableStatId",
                table: "Players",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FavorableStatId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "FavorableStatId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "AspNetUsers");
        }
    }
}
