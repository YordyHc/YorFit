using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YorFit.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branchs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombre = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    D_Distrito = table.Column<string>(type: "text", nullable: false),
                    D_Linea1 = table.Column<string>(type: "text", nullable: false),
                    D_Linea2 = table.Column<string>(type: "text", nullable: true),
                    D_Pais = table.Column<string>(type: "text", nullable: false),
                    D_Provincia = table.Column<string>(type: "text", nullable: false),
                    D_Referencia = table.Column<string>(type: "text", nullable: true),
                    T_CodigoPais = table.Column<string>(type: "text", nullable: false),
                    T_NumeroNacional = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branchs", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_Codigo",
                table: "Branchs",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Branchs_Nombre",
                table: "Branchs",
                column: "Nombre",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Branchs");
        }
    }
}
