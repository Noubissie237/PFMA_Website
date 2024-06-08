using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFMA_Website.Migrations
{
    /// <inheritdoc />
    public partial class newMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actualites",
                columns: table => new
                {
                    ActualiteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    text = table.Column<string>(type: "TEXT", nullable: false),
                    tag = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actualites", x => x.ActualiteID);
                });

            migrationBuilder.CreateTable(
                name: "Descriptifs",
                columns: table => new
                {
                    DescriptifID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    text = table.Column<string>(type: "TEXT", nullable: false),
                    tag = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descriptifs", x => x.DescriptifID);
                });

            migrationBuilder.CreateTable(
                name: "Producteurs",
                columns: table => new
                {
                    ProducteurID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    region = table.Column<string>(type: "TEXT", nullable: true),
                    nom_op = table.Column<string>(type: "TEXT", nullable: true),
                    producteur_paddy_semences = table.Column<string>(type: "TEXT", nullable: true),
                    superficie = table.Column<int>(type: "INTEGER", nullable: false),
                    localistation = table.Column<string>(type: "TEXT", nullable: true),
                    contact = table.Column<string>(type: "TEXT", nullable: true),
                    site_internet = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producteurs", x => x.ProducteurID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    genre = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Vendeurs",
                columns: table => new
                {
                    VendeurID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    region = table.Column<string>(type: "TEXT", nullable: true),
                    nom_vendeur = table.Column<string>(type: "TEXT", nullable: true),
                    type_intrants = table.Column<string>(type: "TEXT", nullable: true),
                    zone_intervention = table.Column<int>(type: "INTEGER", nullable: false),
                    localistation = table.Column<string>(type: "TEXT", nullable: true),
                    contact = table.Column<string>(type: "TEXT", nullable: true),
                    site_internet = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendeurs", x => x.VendeurID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actualites");

            migrationBuilder.DropTable(
                name: "Descriptifs");

            migrationBuilder.DropTable(
                name: "Producteurs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Vendeurs");
        }
    }
}
