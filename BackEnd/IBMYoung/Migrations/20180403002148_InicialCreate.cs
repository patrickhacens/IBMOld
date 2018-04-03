using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IBMYoung.Migrations
{
    public partial class _20180302212126_InicialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Alternativas_AlternativaId",
                table: "Resposta");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Usuarios_AprendizId",
                table: "Resposta");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Questoes_TarefaId_Ordem",
                table: "Resposta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resposta",
                table: "Resposta");

            migrationBuilder.RenameTable(
                name: "Resposta",
                newName: "Respostas");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_TarefaId_Ordem",
                table: "Respostas",
                newName: "IX_Respostas_TarefaId_Ordem");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_AlternativaId",
                table: "Respostas",
                newName: "IX_Respostas_AlternativaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Respostas",
                table: "Respostas",
                columns: new[] { "AprendizId", "TarefaId", "Ordem" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Alternativas_AlternativaId",
                table: "Respostas",
                column: "AlternativaId",
                principalTable: "Alternativas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Usuarios_AprendizId",
                table: "Respostas",
                column: "AprendizId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Questoes_TarefaId_Ordem",
                table: "Respostas",
                columns: new[] { "TarefaId", "Ordem" },
                principalTable: "Questoes",
                principalColumns: new[] { "TarefaId", "Ordem" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Alternativas_AlternativaId",
                table: "Respostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Usuarios_AprendizId",
                table: "Respostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Questoes_TarefaId_Ordem",
                table: "Respostas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Respostas",
                table: "Respostas");

            migrationBuilder.RenameTable(
                name: "Respostas",
                newName: "Resposta");

            migrationBuilder.RenameIndex(
                name: "IX_Respostas_TarefaId_Ordem",
                table: "Resposta",
                newName: "IX_Resposta_TarefaId_Ordem");

            migrationBuilder.RenameIndex(
                name: "IX_Respostas_AlternativaId",
                table: "Resposta",
                newName: "IX_Resposta_AlternativaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resposta",
                table: "Resposta",
                columns: new[] { "AprendizId", "TarefaId", "Ordem" })
                .Annotation("SqlServer:Clustered", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Alternativas_AlternativaId",
                table: "Resposta",
                column: "AlternativaId",
                principalTable: "Alternativas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Usuarios_AprendizId",
                table: "Resposta",
                column: "AprendizId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Questoes_TarefaId_Ordem",
                table: "Resposta",
                columns: new[] { "TarefaId", "Ordem" },
                principalTable: "Questoes",
                principalColumns: new[] { "TarefaId", "Ordem" });
        }
    }
}
