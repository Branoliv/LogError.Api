using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogError.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Level = table.Column<string>(nullable: false),
                    TokenSource = table.Column<string>(nullable: false),
                    Source = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogDetail",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Detail = table.Column<string>(nullable: false),
                    LogInfoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogDetail_LogInfo_LogInfoId",
                        column: x => x.LogInfoId,
                        principalTable: "LogInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogDetail_LogInfoId",
                table: "LogDetail",
                column: "LogInfoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogDetail");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "LogInfo");
        }
    }
}
