using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IBMYoung.Migrations
{
    public partial class RelacaoUsuarioETopico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "Gestor_DataNascimento",
                table: "Usuarios",
                newName: "DataNascimento");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Topicos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Replicas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topicos_UsuarioId",
                table: "Topicos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Replicas_UsuarioId",
                table: "Replicas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Replicas_Usuarios_UsuarioId",
                table: "Replicas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topicos_Usuarios_UsuarioId",
                table: "Topicos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replicas_Usuarios_UsuarioId",
                table: "Replicas");

            migrationBuilder.DropForeignKey(
                name: "FK_Topicos_Usuarios_UsuarioId",
                table: "Topicos");

            migrationBuilder.DropIndex(
                name: "IX_Topicos_UsuarioId",
                table: "Topicos");

            migrationBuilder.DropIndex(
                name: "IX_Replicas_UsuarioId",
                table: "Replicas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Topicos");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Replicas");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "Usuarios",
                newName: "Gestor_DataNascimento");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuarios",
                nullable: true);
        }
    }
}
