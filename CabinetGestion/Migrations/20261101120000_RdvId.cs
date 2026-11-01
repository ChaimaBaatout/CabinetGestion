using Microsoft.EntityFrameworkCore.Migrations;

namespace CabinetGestion.Migrations
{
    public partial class RdvId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RDV",
                table: "RDV");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "RDV",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RDV",
                table: "RDV",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RDV_PatientId",
                table: "RDV",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RDV",
                table: "RDV");

            migrationBuilder.DropIndex(
                name: "IX_RDV_PatientId",
                table: "RDV");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "RDV");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RDV",
                table: "RDV",
                columns: new[] { "PatientId", "MedecinId" });
        }
    }
}