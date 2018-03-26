using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IBMYoung.Migrations
{
    public partial class _230318 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instituicoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instituicoes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Topicos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dataCriacao = table.Column<DateTime>(nullable: false),
                    texto = table.Column<string>(nullable: true),
                    titulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topicos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    active = table.Column<bool>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    tipo = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Replicas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dataCriacao = table.Column<DateTime>(nullable: false),
                    texto = table.Column<string>(nullable: true),
                    topicoid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replicas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Replicas_Topicos_topicoid",
                        column: x => x.topicoid,
                        principalTable: "Topicos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aprendizes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    dataEntrada = table.Column<DateTime>(nullable: false),
                    dataSaida = table.Column<DateTime>(nullable: false),
                    instituicaoid = table.Column<int>(nullable: false),
                    nivel = table.Column<int>(nullable: false),
                    nome = table.Column<string>(nullable: true),
                    sobrenome = table.Column<string>(nullable: true),
                    usuarioid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aprendizes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Aprendizes_Instituicoes_instituicaoid",
                        column: x => x.instituicaoid,
                        principalTable: "Instituicoes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aprendizes_Usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(nullable: true),
                    usuarioid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Boletins",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AprendizID = table.Column<int>(nullable: true),
                    anoReferencia = table.Column<int>(nullable: false),
                    dataCadastro = table.Column<DateTime>(nullable: false),
                    frequencia = table.Column<float>(nullable: false),
                    mesReferencia = table.Column<string>(nullable: true),
                    nota = table.Column<float>(nullable: false),
                    observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletins", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Boletins_Aprendizes_AprendizID",
                        column: x => x.AprendizID,
                        principalTable: "Aprendizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AprendizID = table.Column<int>(nullable: true),
                    active = table.Column<bool>(nullable: false),
                    conteudo = table.Column<string>(nullable: true),
                    dataCriacao = table.Column<DateTime>(nullable: false),
                    dataExclusao = table.Column<DateTime>(nullable: false),
                    entregavel = table.Column<bool>(nullable: false),
                    multEscolha = table.Column<bool>(nullable: false),
                    nivel = table.Column<int>(nullable: false),
                    titulo = table.Column<string>(nullable: true),
                    usuarioid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_Aprendizes_AprendizID",
                        column: x => x.AprendizID,
                        principalTable: "Aprendizes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tarefas_Usuarios_usuarioid",
                        column: x => x.usuarioid,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    conteudo = table.Column<string>(nullable: true),
                    tarefaid = table.Column<int>(nullable: false),
                    titulo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Questoes_Tarefas_tarefaid",
                        column: x => x.tarefaid,
                        principalTable: "Tarefas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alternativas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MyProperty = table.Column<int>(nullable: false),
                    correta = table.Column<bool>(nullable: false),
                    questaoid = table.Column<int>(nullable: false),
                    textoAlternativa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternativas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alternativas_Questoes_questaoid",
                        column: x => x.questaoid,
                        principalTable: "Questoes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternativas_questaoid",
                table: "Alternativas",
                column: "questaoid");

            migrationBuilder.CreateIndex(
                name: "IX_Aprendizes_instituicaoid",
                table: "Aprendizes",
                column: "instituicaoid");

            migrationBuilder.CreateIndex(
                name: "IX_Aprendizes_usuarioid",
                table: "Aprendizes",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Boletins_AprendizID",
                table: "Boletins",
                column: "AprendizID");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_usuarioid",
                table: "Funcionarios",
                column: "usuarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_tarefaid",
                table: "Questoes",
                column: "tarefaid");

            migrationBuilder.CreateIndex(
                name: "IX_Replicas_topicoid",
                table: "Replicas",
                column: "topicoid");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_AprendizID",
                table: "Tarefas",
                column: "AprendizID");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_usuarioid",
                table: "Tarefas",
                column: "usuarioid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alternativas");

            migrationBuilder.DropTable(
                name: "Boletins");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Replicas");

            migrationBuilder.DropTable(
                name: "Questoes");

            migrationBuilder.DropTable(
                name: "Topicos");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Aprendizes");

            migrationBuilder.DropTable(
                name: "Instituicoes");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
