using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IBMYoung.Migrations
{
    public partial class refat_namings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternativas_Questoes_questaoid",
                table: "Alternativas");

            migrationBuilder.DropForeignKey(
                name: "FK_Aprendizes_Instituicoes_instituicaoid",
                table: "Aprendizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Aprendizes_Usuarios_usuarioid",
                table: "Aprendizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Boletins_Aprendizes_AprendizID",
                table: "Boletins");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Usuarios_usuarioid",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Questoes_Tarefas_tarefaid",
                table: "Questoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Replicas_Topicos_topicoid",
                table: "Replicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Aprendizes_AprendizID",
                table: "Tarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_usuarioid",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Alternativas");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Usuarios",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "tipo",
                table: "Usuarios",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "Usuarios",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "Topicos",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "texto",
                table: "Topicos",
                newName: "Texto");

            migrationBuilder.RenameColumn(
                name: "dataCriacao",
                table: "Topicos",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Topicos",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "usuarioid",
                table: "Tarefas",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "Tarefas",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "nivel",
                table: "Tarefas",
                newName: "Nivel");

            migrationBuilder.RenameColumn(
                name: "entregavel",
                table: "Tarefas",
                newName: "Entregavel");

            migrationBuilder.RenameColumn(
                name: "dataExclusao",
                table: "Tarefas",
                newName: "DataExclusao");

            migrationBuilder.RenameColumn(
                name: "dataCriacao",
                table: "Tarefas",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "conteudo",
                table: "Tarefas",
                newName: "Conteudo");

            migrationBuilder.RenameColumn(
                name: "active",
                table: "Tarefas",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "AprendizID",
                table: "Tarefas",
                newName: "AprendizId");

            migrationBuilder.RenameColumn(
                name: "multEscolha",
                table: "Tarefas",
                newName: "MultiEscolha");

            migrationBuilder.RenameIndex(
                name: "IX_Tarefas_usuarioid",
                table: "Tarefas",
                newName: "IX_Tarefas_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Tarefas_AprendizID",
                table: "Tarefas",
                newName: "IX_Tarefas_AprendizId");

            migrationBuilder.RenameColumn(
                name: "topicoid",
                table: "Replicas",
                newName: "TopicoId");

            migrationBuilder.RenameColumn(
                name: "texto",
                table: "Replicas",
                newName: "Texto");

            migrationBuilder.RenameColumn(
                name: "dataCriacao",
                table: "Replicas",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Replicas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Replicas_topicoid",
                table: "Replicas",
                newName: "IX_Replicas_TopicoId");

            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "Questoes",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "tarefaid",
                table: "Questoes",
                newName: "TarefaId");

            migrationBuilder.RenameColumn(
                name: "conteudo",
                table: "Questoes",
                newName: "Conteudo");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Questoes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Questoes_tarefaid",
                table: "Questoes",
                newName: "IX_Questoes_TarefaId");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Instituicoes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Instituicoes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "usuarioid",
                table: "Funcionarios",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Funcionarios",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Funcionarios",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionarios_usuarioid",
                table: "Funcionarios",
                newName: "IX_Funcionarios_UsuarioId");

            migrationBuilder.RenameColumn(
                name: "observacao",
                table: "Boletins",
                newName: "Observacao");

            migrationBuilder.RenameColumn(
                name: "nota",
                table: "Boletins",
                newName: "Nota");

            migrationBuilder.RenameColumn(
                name: "mesReferencia",
                table: "Boletins",
                newName: "MesReferencia");

            migrationBuilder.RenameColumn(
                name: "frequencia",
                table: "Boletins",
                newName: "Frequencia");

            migrationBuilder.RenameColumn(
                name: "dataCadastro",
                table: "Boletins",
                newName: "DataCadastro");

            migrationBuilder.RenameColumn(
                name: "anoReferencia",
                table: "Boletins",
                newName: "AnoReferencia");

            migrationBuilder.RenameColumn(
                name: "AprendizID",
                table: "Boletins",
                newName: "AprendizId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Boletins",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Boletins_AprendizID",
                table: "Boletins",
                newName: "IX_Boletins_AprendizId");

            migrationBuilder.RenameColumn(
                name: "usuarioid",
                table: "Aprendizes",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "sobrenome",
                table: "Aprendizes",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Aprendizes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "nivel",
                table: "Aprendizes",
                newName: "Nivel");

            migrationBuilder.RenameColumn(
                name: "instituicaoid",
                table: "Aprendizes",
                newName: "InstituicaoId");

            migrationBuilder.RenameColumn(
                name: "dataSaida",
                table: "Aprendizes",
                newName: "DataSaida");

            migrationBuilder.RenameColumn(
                name: "dataEntrada",
                table: "Aprendizes",
                newName: "DataEntrada");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Aprendizes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Aprendizes_usuarioid",
                table: "Aprendizes",
                newName: "IX_Aprendizes_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Aprendizes_instituicaoid",
                table: "Aprendizes",
                newName: "IX_Aprendizes_InstituicaoId");

            migrationBuilder.RenameColumn(
                name: "textoAlternativa",
                table: "Alternativas",
                newName: "TextoAlternativa");

            migrationBuilder.RenameColumn(
                name: "questaoid",
                table: "Alternativas",
                newName: "QuestaoId");

            migrationBuilder.RenameColumn(
                name: "correta",
                table: "Alternativas",
                newName: "Correta");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Alternativas",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Alternativas_questaoid",
                table: "Alternativas",
                newName: "IX_Alternativas_QuestaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativas_Questoes_QuestaoId",
                table: "Alternativas",
                column: "QuestaoId",
                principalTable: "Questoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aprendizes_Instituicoes_InstituicaoId",
                table: "Aprendizes",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aprendizes_Usuarios_UsuarioId",
                table: "Aprendizes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boletins_Aprendizes_AprendizId",
                table: "Boletins",
                column: "AprendizId",
                principalTable: "Aprendizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Usuarios_UsuarioId",
                table: "Funcionarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questoes_Tarefas_TarefaId",
                table: "Questoes",
                column: "TarefaId",
                principalTable: "Tarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Replicas_Topicos_TopicoId",
                table: "Replicas",
                column: "TopicoId",
                principalTable: "Topicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Aprendizes_AprendizId",
                table: "Tarefas",
                column: "AprendizId",
                principalTable: "Aprendizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternativas_Questoes_QuestaoId",
                table: "Alternativas");

            migrationBuilder.DropForeignKey(
                name: "FK_Aprendizes_Instituicoes_InstituicaoId",
                table: "Aprendizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Aprendizes_Usuarios_UsuarioId",
                table: "Aprendizes");

            migrationBuilder.DropForeignKey(
                name: "FK_Boletins_Aprendizes_AprendizId",
                table: "Boletins");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Usuarios_UsuarioId",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Questoes_Tarefas_TarefaId",
                table: "Questoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Replicas_Topicos_TopicoId",
                table: "Replicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Aprendizes_AprendizId",
                table: "Tarefas");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Usuarios",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Usuarios",
                newName: "tipo");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Usuarios",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Topicos",
                newName: "titulo");

            migrationBuilder.RenameColumn(
                name: "Texto",
                table: "Topicos",
                newName: "texto");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Topicos",
                newName: "dataCriacao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Topicos",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Tarefas",
                newName: "usuarioid");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Tarefas",
                newName: "titulo");

            migrationBuilder.RenameColumn(
                name: "Nivel",
                table: "Tarefas",
                newName: "nivel");

            migrationBuilder.RenameColumn(
                name: "Entregavel",
                table: "Tarefas",
                newName: "entregavel");

            migrationBuilder.RenameColumn(
                name: "DataExclusao",
                table: "Tarefas",
                newName: "dataExclusao");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Tarefas",
                newName: "dataCriacao");

            migrationBuilder.RenameColumn(
                name: "Conteudo",
                table: "Tarefas",
                newName: "conteudo");

            migrationBuilder.RenameColumn(
                name: "AprendizId",
                table: "Tarefas",
                newName: "AprendizID");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Tarefas",
                newName: "active");

            migrationBuilder.RenameColumn(
                name: "MultiEscolha",
                table: "Tarefas",
                newName: "multEscolha");

            migrationBuilder.RenameIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "Tarefas",
                newName: "IX_Tarefas_usuarioid");

            migrationBuilder.RenameIndex(
                name: "IX_Tarefas_AprendizId",
                table: "Tarefas",
                newName: "IX_Tarefas_AprendizID");

            migrationBuilder.RenameColumn(
                name: "TopicoId",
                table: "Replicas",
                newName: "topicoid");

            migrationBuilder.RenameColumn(
                name: "Texto",
                table: "Replicas",
                newName: "texto");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "Replicas",
                newName: "dataCriacao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Replicas",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Replicas_TopicoId",
                table: "Replicas",
                newName: "IX_Replicas_topicoid");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Questoes",
                newName: "titulo");

            migrationBuilder.RenameColumn(
                name: "TarefaId",
                table: "Questoes",
                newName: "tarefaid");

            migrationBuilder.RenameColumn(
                name: "Conteudo",
                table: "Questoes",
                newName: "conteudo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Questoes",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Questoes_TarefaId",
                table: "Questoes",
                newName: "IX_Questoes_tarefaid");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Instituicoes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Instituicoes",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Funcionarios",
                newName: "usuarioid");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Funcionarios",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Funcionarios",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionarios_UsuarioId",
                table: "Funcionarios",
                newName: "IX_Funcionarios_usuarioid");

            migrationBuilder.RenameColumn(
                name: "Observacao",
                table: "Boletins",
                newName: "observacao");

            migrationBuilder.RenameColumn(
                name: "Nota",
                table: "Boletins",
                newName: "nota");

            migrationBuilder.RenameColumn(
                name: "MesReferencia",
                table: "Boletins",
                newName: "mesReferencia");

            migrationBuilder.RenameColumn(
                name: "Frequencia",
                table: "Boletins",
                newName: "frequencia");

            migrationBuilder.RenameColumn(
                name: "DataCadastro",
                table: "Boletins",
                newName: "dataCadastro");

            migrationBuilder.RenameColumn(
                name: "AprendizId",
                table: "Boletins",
                newName: "AprendizID");

            migrationBuilder.RenameColumn(
                name: "AnoReferencia",
                table: "Boletins",
                newName: "anoReferencia");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Boletins",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Boletins_AprendizId",
                table: "Boletins",
                newName: "IX_Boletins_AprendizID");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Aprendizes",
                newName: "usuarioid");

            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Aprendizes",
                newName: "sobrenome");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Aprendizes",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Nivel",
                table: "Aprendizes",
                newName: "nivel");

            migrationBuilder.RenameColumn(
                name: "InstituicaoId",
                table: "Aprendizes",
                newName: "instituicaoid");

            migrationBuilder.RenameColumn(
                name: "DataSaida",
                table: "Aprendizes",
                newName: "dataSaida");

            migrationBuilder.RenameColumn(
                name: "DataEntrada",
                table: "Aprendizes",
                newName: "dataEntrada");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Aprendizes",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Aprendizes_UsuarioId",
                table: "Aprendizes",
                newName: "IX_Aprendizes_usuarioid");

            migrationBuilder.RenameIndex(
                name: "IX_Aprendizes_InstituicaoId",
                table: "Aprendizes",
                newName: "IX_Aprendizes_instituicaoid");

            migrationBuilder.RenameColumn(
                name: "TextoAlternativa",
                table: "Alternativas",
                newName: "textoAlternativa");

            migrationBuilder.RenameColumn(
                name: "QuestaoId",
                table: "Alternativas",
                newName: "questaoid");

            migrationBuilder.RenameColumn(
                name: "Correta",
                table: "Alternativas",
                newName: "correta");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Alternativas",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Alternativas_QuestaoId",
                table: "Alternativas",
                newName: "IX_Alternativas_questaoid");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Alternativas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativas_Questoes_questaoid",
                table: "Alternativas",
                column: "questaoid",
                principalTable: "Questoes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aprendizes_Instituicoes_instituicaoid",
                table: "Aprendizes",
                column: "instituicaoid",
                principalTable: "Instituicoes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Aprendizes_Usuarios_usuarioid",
                table: "Aprendizes",
                column: "usuarioid",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Boletins_Aprendizes_AprendizID",
                table: "Boletins",
                column: "AprendizID",
                principalTable: "Aprendizes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Usuarios_usuarioid",
                table: "Funcionarios",
                column: "usuarioid",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Questoes_Tarefas_tarefaid",
                table: "Questoes",
                column: "tarefaid",
                principalTable: "Tarefas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Replicas_Topicos_topicoid",
                table: "Replicas",
                column: "topicoid",
                principalTable: "Topicos",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Aprendizes_AprendizID",
                table: "Tarefas",
                column: "AprendizID",
                principalTable: "Aprendizes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_usuarioid",
                table: "Tarefas",
                column: "usuarioid",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
