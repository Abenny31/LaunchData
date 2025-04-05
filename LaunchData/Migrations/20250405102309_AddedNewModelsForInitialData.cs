using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaunchData.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewModelsForInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Success",
                table: "LaunchModels",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<bool>(
                name: "AutoUpdate",
                table: "LaunchModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Capsules",
                table: "LaunchModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Crew",
                table: "LaunchModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "DateLocal",
                table: "LaunchModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DatePrecision",
                table: "LaunchModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "DateUnix",
                table: "LaunchModels",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "FairingsId",
                table: "LaunchModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FlightNumber",
                table: "LaunchModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "LaunchLibraryId",
                table: "LaunchModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Launchpad",
                table: "LaunchModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LinksId",
                table: "LaunchModels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Net",
                table: "LaunchModels",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Payloads",
                table: "LaunchModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Ships",
                table: "LaunchModels",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<long>(
                name: "StaticFireDateUnix",
                table: "LaunchModels",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StaticFireDateUtc",
                table: "LaunchModels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Tbd",
                table: "LaunchModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Upcoming",
                table: "LaunchModels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Window",
                table: "LaunchModels",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Cores",
                columns: table => new
                {
                    CoreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Flight = table.Column<int>(type: "int", nullable: true),
                    Gridfins = table.Column<bool>(type: "bit", nullable: true),
                    Legs = table.Column<bool>(type: "bit", nullable: true),
                    Reused = table.Column<bool>(type: "bit", nullable: true),
                    LandingAttempt = table.Column<bool>(type: "bit", nullable: true),
                    LandingSuccess = table.Column<bool>(type: "bit", nullable: true),
                    LandingType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Landpad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaunchModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cores", x => x.CoreId);
                    table.ForeignKey(
                        name: "FK_Cores_LaunchModels_LaunchModelId",
                        column: x => x.LaunchModelId,
                        principalTable: "LaunchModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Failures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<int>(type: "int", nullable: true),
                    Altitude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LaunchModelId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Failures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Failures_LaunchModels_LaunchModelId",
                        column: x => x.LaunchModelId,
                        principalTable: "LaunchModels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fairings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reused = table.Column<bool>(type: "bit", nullable: true),
                    RecoveryAttempt = table.Column<bool>(type: "bit", nullable: true),
                    Recovered = table.Column<bool>(type: "bit", nullable: true),
                    Ships = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fairings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flickr",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Small = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Original = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flickr", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patch",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Small = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Large = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reddit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Campaign = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Launch = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Media = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Recovery = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reddit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Links",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatchId = table.Column<int>(type: "int", nullable: false),
                    RedditId = table.Column<int>(type: "int", nullable: false),
                    FlickrId = table.Column<int>(type: "int", nullable: false),
                    Presskit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Webcast = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Article = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wikipedia = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Links", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Links_Flickr_FlickrId",
                        column: x => x.FlickrId,
                        principalTable: "Flickr",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Patch_PatchId",
                        column: x => x.PatchId,
                        principalTable: "Patch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Links_Reddit_RedditId",
                        column: x => x.RedditId,
                        principalTable: "Reddit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LaunchModels_FairingsId",
                table: "LaunchModels",
                column: "FairingsId");

            migrationBuilder.CreateIndex(
                name: "IX_LaunchModels_LinksId",
                table: "LaunchModels",
                column: "LinksId");

            migrationBuilder.CreateIndex(
                name: "IX_Cores_LaunchModelId",
                table: "Cores",
                column: "LaunchModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Failures_LaunchModelId",
                table: "Failures",
                column: "LaunchModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_FlickrId",
                table: "Links",
                column: "FlickrId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_PatchId",
                table: "Links",
                column: "PatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Links_RedditId",
                table: "Links",
                column: "RedditId");

            migrationBuilder.AddForeignKey(
                name: "FK_LaunchModels_Fairings_FairingsId",
                table: "LaunchModels",
                column: "FairingsId",
                principalTable: "Fairings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LaunchModels_Links_LinksId",
                table: "LaunchModels",
                column: "LinksId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LaunchModels_Fairings_FairingsId",
                table: "LaunchModels");

            migrationBuilder.DropForeignKey(
                name: "FK_LaunchModels_Links_LinksId",
                table: "LaunchModels");

            migrationBuilder.DropTable(
                name: "Cores");

            migrationBuilder.DropTable(
                name: "Failures");

            migrationBuilder.DropTable(
                name: "Fairings");

            migrationBuilder.DropTable(
                name: "Links");

            migrationBuilder.DropTable(
                name: "Flickr");

            migrationBuilder.DropTable(
                name: "Patch");

            migrationBuilder.DropTable(
                name: "Reddit");

            migrationBuilder.DropIndex(
                name: "IX_LaunchModels_FairingsId",
                table: "LaunchModels");

            migrationBuilder.DropIndex(
                name: "IX_LaunchModels_LinksId",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "AutoUpdate",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "Capsules",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "Crew",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "DateLocal",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "DatePrecision",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "DateUnix",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "FairingsId",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "FlightNumber",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "LaunchLibraryId",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "Launchpad",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "LinksId",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "Net",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "Payloads",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "Ships",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "StaticFireDateUnix",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "StaticFireDateUtc",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "Tbd",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "Upcoming",
                table: "LaunchModels");

            migrationBuilder.DropColumn(
                name: "Window",
                table: "LaunchModels");

            migrationBuilder.AlterColumn<bool>(
                name: "Success",
                table: "LaunchModels",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
