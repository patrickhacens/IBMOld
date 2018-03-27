using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IBMYoung.Migrations
{
    public partial class dfsakjalsfksa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boletins_Aprendizes_AprendizId",
                table: "Boletins");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Aprendizes_AprendizId",
                table: "Tarefas");

            migrationBuilder.DropTable(
                name: "Aprendizes");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Tarefas_AprendizId",
                table: "Tarefas");

            migrationBuilder.DropColumn(
                name: "AprendizId",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Usuarios",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Tipo",
                table: "Usuarios",
                newName: "Sobrenome");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Usuarios",
                newName: "Discriminator");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "Usuarios",
                newName: "TwoFactorEnabled");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Usuarios",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrada",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSaida",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstituicaoId",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Nivel",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Usuarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Usuarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Usuarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordSalt",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Usuarios",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_InstituicaoId",
                table: "Usuarios",
                column: "InstituicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boletins_Usuarios_AprendizId",
                table: "Boletins",
                column: "AprendizId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Instituicoes_InstituicaoId",
                table: "Usuarios",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Boletins_Usuarios_AprendizId",
                table: "Boletins");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Instituicoes_InstituicaoId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_InstituicaoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataEntrada",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "DataSaida",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "InstituicaoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nivel",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Usuarios",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "TwoFactorEnabled",
                table: "Usuarios",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "Usuarios",
                newName: "Tipo");

            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "Usuarios",
                newName: "Password");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AprendizId",
                table: "Tarefas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Aprendizes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataSaida = table.Column<DateTime>(nullable: false),
                    InstituicaoId = table.Column<int>(nullable: false),
                    Nivel = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aprendizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aprendizes_Instituicoes_InstituicaoId",
                        column: x => x.InstituicaoId,
                        principalTable: "Instituicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aprendizes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_AprendizId",
                table: "Tarefas",
                column: "AprendizId");

            migrationBuilder.CreateIndex(
                name: "IX_Aprendizes_InstituicaoId",
                table: "Aprendizes",
                column: "InstituicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Aprendizes_UsuarioId",
                table: "Aprendizes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_UsuarioId",
                table: "Funcionarios",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Boletins_Aprendizes_AprendizId",
                table: "Boletins",
                column: "AprendizId",
                principalTable: "Aprendizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Aprendizes_AprendizId",
                table: "Tarefas",
                column: "AprendizId",
                principalTable: "Aprendizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
