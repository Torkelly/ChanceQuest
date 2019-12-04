using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ChanceQuest.Migrations
{
    public partial class EntityUpdate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quests_Factions_FactionTypeId",
                table: "Quests");

            migrationBuilder.DropTable(
                name: "Factions");

            migrationBuilder.DropIndex(
                name: "IX_Quests_FactionTypeId",
                table: "Quests");

            migrationBuilder.DropColumn(
                name: "FactionTypeId",
                table: "Quests");

            migrationBuilder.AddColumn<int>(
                name: "FactionId",
                table: "Quests",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FactionId",
                table: "Quests");

            migrationBuilder.AddColumn<int>(
                name: "FactionTypeId",
                table: "Quests",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Factions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FactionName = table.Column<string>(nullable: true),
                    Happiness = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factions", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Quests_FactionTypeId",
                table: "Quests",
                column: "FactionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quests_Factions_FactionTypeId",
                table: "Quests",
                column: "FactionTypeId",
                principalTable: "Factions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
