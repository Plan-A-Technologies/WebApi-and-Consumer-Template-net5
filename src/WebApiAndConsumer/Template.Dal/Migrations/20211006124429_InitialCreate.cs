using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Dal.Migrations
{
    public partial class InitialCreate : Migration
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected override void Up(MigrationBuilder migrationBuilder)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreferredName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerHeight = table.Column<int>(type: "int", nullable: false),
                    PlayerWeight = table.Column<int>(type: "int", nullable: false),
                    HairColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EyeColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerNationality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlayerVip = table.Column<bool>(type: "bit", nullable: false),
                    PlayerActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlayerPhones",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlayerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CallToPhone = table.Column<bool>(type: "bit", nullable: false),
                    PrimaryPhone = table.Column<bool>(type: "bit", nullable: false),
                    SendTextMessage = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerPhones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlayerPhones_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerPhones_PlayerId",
                schema: "dbo",
                table: "PlayerPhones",
                column: "PlayerId");
        }

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        protected override void Down(MigrationBuilder migrationBuilder)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            migrationBuilder.DropTable(
                name: "PlayerPhones",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
