using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Bahrain.API.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "atcontrollers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(maxLength: 2, nullable: false),
                    NetworkId = table.Column<string>(nullable: false),
                    HasSignOff = table.Column<bool>(nullable: false),
                    OnSolo = table.Column<bool>(nullable: false),
                    ApprovedPositions = table.Column<string>(nullable: false),
                    HomeVacc = table.Column<string>(nullable: false),
                    Visitor = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_atcontrollers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffMember",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    FullName = table.Column<string>(nullable: false),
                    StaffCallsign = table.Column<string>(nullable: false),
                    NetworkId = table.Column<string>(nullable: false),
                    PermissionPower = table.Column<int>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    StaffEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMember", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "atcontrollers");

            migrationBuilder.DropTable(
                name: "StaffMember");
        }
    }
}
