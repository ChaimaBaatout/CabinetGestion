using Microsoft.EntityFrameworkCore.Migrations;

namespace CabinetGestion.Migrations
{
    public partial class test4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RDV_Utilisateur_MedecinId",
                table: "RDV");

            migrationBuilder.DropForeignKey(
                name: "FK_RDV_Utilisateur_PatientId",
                table: "RDV");

            migrationBuilder.AddForeignKey(
                name: "FK_RDV_Utilisateur_MedecinId",
                table: "RDV",
                column: "MedecinId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_RDV_Utilisateur_PatientId",
                table: "RDV",
                column: "PatientId",
                principalTable: "Utilisateur",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RDV_Utilisateur_MedecinId",
                table: "RDV");

            migrationBuilder.DropForeignKey(
                name: "FK_RDV_Utilisateur_PatientId",
                table: "RDV");

            migrationBuilder.AddForeignKey(
                name: "FK_RDV_Utilisateur_MedecinId",
                table: "RDV",
                column: "MedecinId",
                principalTable: "Utilisateur",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RDV_Utilisateur_PatientId",
                table: "RDV",
                column: "PatientId",
                principalTable: "Utilisateur",
                principalColumn: "Id");
        }
    }
}
