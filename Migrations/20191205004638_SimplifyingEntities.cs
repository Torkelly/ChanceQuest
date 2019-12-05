using Microsoft.EntityFrameworkCore.Migrations;

namespace ChanceQuest.Migrations
{
    public partial class SimplifyingEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Players",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "FactionId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "HappyMinus",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "HappyPlus",
                table: "Quests");

            migrationBuilder.RenameTable(
                name: "Players",
                newName: "Player");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Quests",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "CharacterName",
                table: "Player",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavorableStatId",
                table: "Player",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Player",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Player",
                table: "Player",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Player",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "CharacterName",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "FavorableStatId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Player");

            migrationBuilder.RenameTable(
                name: "Player",
                newName: "Players");

            migrationBuilder.AddColumn<int>(
                name: "FactionId",
                table: "Quests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HappyMinus",
                table: "Quests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HappyPlus",
                table: "Quests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Players",
                table: "Players",
                column: "Id");
        }
    }
}
