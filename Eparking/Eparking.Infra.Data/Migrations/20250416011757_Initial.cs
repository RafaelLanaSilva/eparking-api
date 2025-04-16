using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eparking.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_ESTACIONAMENTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ENDERECO = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    QTD_VAGAS_CARRO = table.Column<int>(type: "int", nullable: false),
                    QTD_VAGAS_MOTOCICLETA = table.Column<int>(type: "int", nullable: false),
                    QTD_VAGAS_PREFERENCIAL = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESTACIONAMENTO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_VEICULO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MODELO = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PLACA = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    COR = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TipoVeiculo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VEICULO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TB_TARIFA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ESTACIONAMENTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TIPO_VEICULO = table.Column<int>(type: "int", nullable: false),
                    VALOR_HORA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VALOR_FRACAO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TOLERANCIA_MINUTOS = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TARIFA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_TARIFA_TB_ESTACIONAMENTO_ESTACIONAMENTO_ID",
                        column: x => x.ESTACIONAMENTO_ID,
                        principalTable: "TB_ESTACIONAMENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_VAGA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NUMERO = table.Column<int>(type: "int", nullable: false),
                    TIPO_VAGA = table.Column<int>(type: "int", nullable: false),
                    OCUPADO = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    ESTACIONAMENTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VAGA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_VAGA_TB_ESTACIONAMENTO_ESTACIONAMENTO_ID",
                        column: x => x.ESTACIONAMENTO_ID,
                        principalTable: "TB_ESTACIONAMENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TB_MOVIMENTACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ESTACIONAMENTO_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VAGA_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VeiculoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HORA_ENTRADA = table.Column<DateTime>(type: "datetime", nullable: false),
                    HORA_SAIDA = table.Column<DateTime>(type: "datetime", nullable: true),
                    VALOR_COBRADO = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MOVIMENTACAO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TB_MOVIMENTACAO_TB_ESTACIONAMENTO_ESTACIONAMENTO_ID",
                        column: x => x.ESTACIONAMENTO_ID,
                        principalTable: "TB_ESTACIONAMENTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TB_MOVIMENTACAO_TB_VAGA_VAGA_ID",
                        column: x => x.VAGA_ID,
                        principalTable: "TB_VAGA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_MOVIMENTACAO_TB_VEICULO_VeiculoId",
                        column: x => x.VeiculoId,
                        principalTable: "TB_VEICULO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_MOVIMENTACAO_ESTACIONAMENTO_ID",
                table: "TB_MOVIMENTACAO",
                column: "ESTACIONAMENTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MOVIMENTACAO_VAGA_ID",
                table: "TB_MOVIMENTACAO",
                column: "VAGA_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_MOVIMENTACAO_VeiculoId",
                table: "TB_MOVIMENTACAO",
                column: "VeiculoId");

            migrationBuilder.CreateIndex(
                name: "IX_TB_TARIFA_ESTACIONAMENTO_ID",
                table: "TB_TARIFA",
                column: "ESTACIONAMENTO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VAGA_ESTACIONAMENTO_ID",
                table: "TB_VAGA",
                column: "ESTACIONAMENTO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_MOVIMENTACAO");

            migrationBuilder.DropTable(
                name: "TB_TARIFA");

            migrationBuilder.DropTable(
                name: "TB_VAGA");

            migrationBuilder.DropTable(
                name: "TB_VEICULO");

            migrationBuilder.DropTable(
                name: "TB_ESTACIONAMENTO");
        }
    }
}
