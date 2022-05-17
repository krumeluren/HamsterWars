using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hamster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    FavFood = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Loves = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Img_Src = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: true),
                    Losses = table.Column<int>(type: "int", nullable: true),
                    Games = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Battle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeOfPost = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WinnerHamsterId = table.Column<int>(type: "int", nullable: false),
                    LoserHamsterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Battle_Hamster_LoserHamsterId",
                        column: x => x.LoserHamsterId,
                        principalTable: "Hamster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Battle_Hamster_WinnerHamsterId",
                        column: x => x.WinnerHamsterId,
                        principalTable: "Hamster",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battle_LoserHamsterId",
                table: "Battle",
                column: "LoserHamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Battle_WinnerHamsterId",
                table: "Battle",
                column: "WinnerHamsterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Battle");

            migrationBuilder.DropTable(
                name: "Hamster");
        }
    }
}
