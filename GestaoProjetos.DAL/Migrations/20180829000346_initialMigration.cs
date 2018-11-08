using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoProjetos.DAL.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    Id_Cargo = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.Id_Cargo);
                });

            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id_Projeto = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Razao_Social = table.Column<string>(nullable: true),
                    CNPJ = table.Column<string>(nullable: true),
                    Horas_Projeto = table.Column<double>(nullable: false),
                    Data_Inicial_Contrato = table.Column<DateTime>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id_Projeto);
                });

            migrationBuilder.CreateTable(
                name: "Colaborador",
                columns: table => new
                {
                    Id_Colaborador = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    CargoId_Cargo = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaborador", x => x.Id_Colaborador);
                    table.ForeignKey(
                        name: "FK_Colaborador_Cargo_CargoId_Cargo",
                        column: x => x.CargoId_Cargo,
                        principalTable: "Cargo",
                        principalColumn: "Id_Cargo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id_Tarefa = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Observacao = table.Column<string>(nullable: true),
                    Situacao = table.Column<string>(nullable: false),
                    Data_Abertura = table.Column<DateTime>(nullable: false),
                    Data_Entrega = table.Column<DateTime>(nullable: false),
                    ProjetoId_Projeto = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id_Tarefa);
                    table.ForeignKey(
                        name: "FK_Tarefa_Projeto_ProjetoId_Projeto",
                        column: x => x.ProjetoId_Projeto,
                        principalTable: "Projeto",
                        principalColumn: "Id_Projeto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ColaboradorTarefa",
                columns: table => new
                {
                    ID_ColaboradorTarefa = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColaboradorId_Colaborador = table.Column<long>(nullable: true),
                    TarefaId_Tarefa = table.Column<long>(nullable: true),
                    Horas_Estimadas = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ColaboradorTarefa", x => x.ID_ColaboradorTarefa);
                    table.ForeignKey(
                        name: "FK_ColaboradorTarefa_Colaborador_ColaboradorId_Colaborador",
                        column: x => x.ColaboradorId_Colaborador,
                        principalTable: "Colaborador",
                        principalColumn: "Id_Colaborador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ColaboradorTarefa_Tarefa_TarefaId_Tarefa",
                        column: x => x.TarefaId_Tarefa,
                        principalTable: "Tarefa",
                        principalColumn: "Id_Tarefa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HorasColaborador",
                columns: table => new
                {
                    Id_HorasColaborador = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColaboradorId_Colaborador = table.Column<long>(nullable: true),
                    TarefaId_Tarefa = table.Column<long>(nullable: true),
                    Horas = table.Column<double>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorasColaborador", x => x.Id_HorasColaborador);
                    table.ForeignKey(
                        name: "FK_HorasColaborador_Colaborador_ColaboradorId_Colaborador",
                        column: x => x.ColaboradorId_Colaborador,
                        principalTable: "Colaborador",
                        principalColumn: "Id_Colaborador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HorasColaborador_Tarefa_TarefaId_Tarefa",
                        column: x => x.TarefaId_Tarefa,
                        principalTable: "Tarefa",
                        principalColumn: "Id_Tarefa",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colaborador_CargoId_Cargo",
                table: "Colaborador",
                column: "CargoId_Cargo");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorTarefa_ColaboradorId_Colaborador",
                table: "ColaboradorTarefa",
                column: "ColaboradorId_Colaborador");

            migrationBuilder.CreateIndex(
                name: "IX_ColaboradorTarefa_TarefaId_Tarefa",
                table: "ColaboradorTarefa",
                column: "TarefaId_Tarefa");

            migrationBuilder.CreateIndex(
                name: "IX_HorasColaborador_ColaboradorId_Colaborador",
                table: "HorasColaborador",
                column: "ColaboradorId_Colaborador");

            migrationBuilder.CreateIndex(
                name: "IX_HorasColaborador_TarefaId_Tarefa",
                table: "HorasColaborador",
                column: "TarefaId_Tarefa");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ProjetoId_Projeto",
                table: "Tarefa",
                column: "ProjetoId_Projeto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ColaboradorTarefa");

            migrationBuilder.DropTable(
                name: "HorasColaborador");

            migrationBuilder.DropTable(
                name: "Colaborador");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Projeto");
        }
    }
}
