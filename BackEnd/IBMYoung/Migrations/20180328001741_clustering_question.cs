using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IBMYoung.Migrations
{
    public partial class clustering_question : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternativas_Questoes_QuestaoId",
                table: "Alternativas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questoes",
                table: "Questoes");

            migrationBuilder.DropIndex(
                name: "IX_Questoes_TarefaId",
                table: "Questoes");

            migrationBuilder.DropIndex(
                name: "IX_Alternativas_QuestaoId",
                table: "Alternativas");

            migrationBuilder.DropColumn(
                name: "Entregavel",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "MultiEscolha",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Questoes");

            migrationBuilder.DropColumn(
                name: "QuestaoId",
                table: "Alternativas");

            migrationBuilder.AddColumn<int>(
                name: "Ordem",
                table: "Questoes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestaoOrdem",
                table: "Alternativas",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestaoTarefaId",
                table: "Alternativas",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questoes",
                table: "Questoes",
                columns: new[] { "TarefaId", "Ordem" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.CreateIndex(
                name: "IX_Alternativas_QuestaoTarefaId_QuestaoOrdem",
                table: "Alternativas",
                columns: new[] { "QuestaoTarefaId", "QuestaoOrdem" });

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativas_Questoes_QuestaoTarefaId_QuestaoOrdem",
                table: "Alternativas",
                columns: new[] { "QuestaoTarefaId", "QuestaoOrdem" },
                principalTable: "Questoes",
                principalColumns: new[] { "TarefaId", "Ordem" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternativas_Questoes_QuestaoTarefaId_QuestaoOrdem",
                table: "Alternativas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Questoes",
                table: "Questoes");

            migrationBuilder.DropIndex(
                name: "IX_Alternativas_QuestaoTarefaId_QuestaoOrdem",
                table: "Alternativas");

            migrationBuilder.DropColumn(
                name: "Ordem",
                table: "Questoes");

            migrationBuilder.DropColumn(
                name: "QuestaoOrdem",
                table: "Alternativas");

            migrationBuilder.DropColumn(
                name: "QuestaoTarefaId",
                table: "Alternativas");

            migrationBuilder.AddColumn<bool>(
                name: "Entregavel",
                table: "Tarefas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MultiEscolha",
                table: "Tarefas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Questoes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "QuestaoId",
                table: "Alternativas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Questoes",
                table: "Questoes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_TarefaId",
                table: "Questoes",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alternativas_QuestaoId",
                table: "Alternativas",
                column: "QuestaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativas_Questoes_QuestaoId",
                table: "Alternativas",
                column: "QuestaoId",
                principalTable: "Questoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
