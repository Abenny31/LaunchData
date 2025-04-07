using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LaunchData.Migrations
{
    /// <inheritdoc />
    public partial class changedmodelsv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Flickr_FlickrId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Patch_PatchId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Reddit_RedditId",
                table: "Links");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cores",
                table: "Cores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reddit",
                table: "Reddit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patch",
                table: "Patch");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flickr",
                table: "Flickr");

            migrationBuilder.RenameTable(
                name: "Reddit",
                newName: "Reddits");

            migrationBuilder.RenameTable(
                name: "Patch",
                newName: "Patches");

            migrationBuilder.RenameTable(
                name: "Flickr",
                newName: "Flickrs");

            migrationBuilder.AlterColumn<bool>(
                name: "Net",
                table: "LaunchModels",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Time",
                table: "Failures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Altitude",
                table: "Failures",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LaunchId",
                table: "Failures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "CoreId",
                table: "Cores",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Cores",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "LandpadId",
                table: "Cores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LaunchId",
                table: "Cores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cores",
                table: "Cores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reddits",
                table: "Reddits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patches",
                table: "Patches",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flickrs",
                table: "Flickrs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Payloads",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MassKg = table.Column<double>(type: "float", nullable: true),
                    Orbit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payloads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rockets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Launchpads",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Launchpads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Launchpads_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Launchpads_LocationId",
                table: "Launchpads",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Flickrs_FlickrId",
                table: "Links",
                column: "FlickrId",
                principalTable: "Flickrs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Patches_PatchId",
                table: "Links",
                column: "PatchId",
                principalTable: "Patches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Reddits_RedditId",
                table: "Links",
                column: "RedditId",
                principalTable: "Reddits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Links_Flickrs_FlickrId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Patches_PatchId",
                table: "Links");

            migrationBuilder.DropForeignKey(
                name: "FK_Links_Reddits_RedditId",
                table: "Links");

            migrationBuilder.DropTable(
                name: "Launchpads");

            migrationBuilder.DropTable(
                name: "Payloads");

            migrationBuilder.DropTable(
                name: "Rockets");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cores",
                table: "Cores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reddits",
                table: "Reddits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patches",
                table: "Patches");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flickrs",
                table: "Flickrs");

            migrationBuilder.DropColumn(
                name: "LaunchId",
                table: "Failures");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Cores");

            migrationBuilder.DropColumn(
                name: "LandpadId",
                table: "Cores");

            migrationBuilder.DropColumn(
                name: "LaunchId",
                table: "Cores");

            migrationBuilder.RenameTable(
                name: "Reddits",
                newName: "Reddit");

            migrationBuilder.RenameTable(
                name: "Patches",
                newName: "Patch");

            migrationBuilder.RenameTable(
                name: "Flickrs",
                newName: "Flickr");

            migrationBuilder.AlterColumn<bool>(
                name: "Net",
                table: "LaunchModels",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<int>(
                name: "Time",
                table: "Failures",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Altitude",
                table: "Failures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CoreId",
                table: "Cores",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cores",
                table: "Cores",
                column: "CoreId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reddit",
                table: "Reddit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patch",
                table: "Patch",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flickr",
                table: "Flickr",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Flickr_FlickrId",
                table: "Links",
                column: "FlickrId",
                principalTable: "Flickr",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Patch_PatchId",
                table: "Links",
                column: "PatchId",
                principalTable: "Patch",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Links_Reddit_RedditId",
                table: "Links",
                column: "RedditId",
                principalTable: "Reddit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
