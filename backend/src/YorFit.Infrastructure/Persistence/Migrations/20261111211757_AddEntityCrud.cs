using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YorFit.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddEntityCrud : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nombres = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Apellidos = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Activo = table.Column<bool>(type: "boolean", nullable: false),
                    D_Distrito = table.Column<string>(type: "text", nullable: false),
                    D_Linea1 = table.Column<string>(type: "text", nullable: false),
                    D_Linea2 = table.Column<string>(type: "text", nullable: true),
                    D_Pais = table.Column<string>(type: "text", nullable: false),
                    D_Provincia = table.Column<string>(type: "text", nullable: false),
                    D_Referencia = table.Column<string>(type: "text", nullable: true),
                    DI_Numero = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    DI_Tipo = table.Column<int>(type: "integer", nullable: false),
                    T_CodigoPais = table.Column<string>(type: "text", nullable: false),
                    T_NumeroNacional = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPersona = table.Column<Guid>(type: "uuid", nullable: false),
                    Cargo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    SalaryAmount = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    SalaryCurrency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Persons_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPersona = table.Column<Guid>(type: "uuid", nullable: false),
                    CodigoSocio = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Members_Persons_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdPersona = table.Column<Guid>(type: "uuid", nullable: false),
                    IdSede = table.Column<Guid>(type: "uuid", nullable: false),
                    IdRol = table.Column<Guid>(type: "uuid", nullable: false),
                    NombreUsuario = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(254)", maxLength: 254, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false),
                    RequiereCambioPassword = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Branchs_IdSede",
                        column: x => x.IdSede,
                        principalTable: "Branchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Persons_IdPersona",
                        column: x => x.IdPersona,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdEmpleado = table.Column<Guid>(type: "uuid", nullable: false),
                    Especialidad = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_Employees_IdEmpleado",
                        column: x => x.IdEmpleado,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IdPersona",
                table: "Employees",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Members_CodigoSocio",
                table: "Members",
                column: "CodigoSocio",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_IdPersona",
                table: "Members",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Trainers_IdEmpleado",
                table: "Trainers",
                column: "IdEmpleado");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdPersona",
                table: "Users",
                column: "IdPersona");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRol",
                table: "Users",
                column: "IdRol");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdSede",
                table: "Users",
                column: "IdSede");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NombreUsuario",
                table: "Users",
                column: "NombreUsuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
