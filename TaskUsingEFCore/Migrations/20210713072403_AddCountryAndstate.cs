using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskUsingEFCore.Migrations
{
    public partial class AddCountryAndstate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "personProperties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonPlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonBillingIntervel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonStreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonState = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonOldPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonNewPassword = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_personProperties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "personProperties");
        }
    }
}
