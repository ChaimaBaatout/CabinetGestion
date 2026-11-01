using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CabinetGestion.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DateDeTravail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Jours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeureDebut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeureFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateDeTravail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Specialite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSpecialite = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateur",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mdp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrixVisite = table.Column<int>(type: "int", nullable: true),
                    Activate = table.Column<bool>(type: "bit", nullable: true),
                    Cin = table.Column<int>(type: "int", nullable: true),
                    SpecialiteID = table.Column<int>(type: "int", nullable: true),
                    DateDeTravailId = table.Column<int>(type: "int", nullable: true),
                    Cnss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateDenaiss = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateur", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utilisateur_DateDeTravail_DateDeTravailId",
                        column: x => x.DateDeTravailId,
                        principalTable: "DateDeTravail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction );
                        ;
                    table.ForeignKey(
                        name: "FK_Utilisateur_Specialite_SpecialiteID",
                        column: x => x.SpecialiteID,
                        principalTable: "Specialite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "RDV",
                columns: table => new
                {
                    MedecinId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DateRDV = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ordonnance = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RDV", x => new { x.PatientId, x.MedecinId });
                    table.ForeignKey(
                        name: "FK_RDV_Utilisateur_MedecinId",
                        column: x => x.MedecinId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RDV_Utilisateur_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Utilisateur",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RDV_MedecinId",
                table: "RDV",
                column: "MedecinId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_DateDeTravailId",
                table: "Utilisateur",
                column: "DateDeTravailId");

            migrationBuilder.CreateIndex(
                name: "IX_Utilisateur_SpecialiteID",
                table: "Utilisateur",
                column: "SpecialiteID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RDV");

            migrationBuilder.DropTable(
                name: "Utilisateur");

            migrationBuilder.DropTable(
                name: "DateDeTravail");

            migrationBuilder.DropTable(
                name: "Specialite");
        }
    }
}
