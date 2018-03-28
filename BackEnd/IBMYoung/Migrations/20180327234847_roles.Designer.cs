﻿// <auto-generated />
using IBMYoung.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace IBMYoung.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20180327234847_roles")]
    partial class roles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IBMYoung.Model.Alternativa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Correta");

                    b.Property<int>("QuestaoId");

                    b.Property<string>("TextoAlternativa");

                    b.HasKey("Id");

                    b.HasIndex("QuestaoId");

                    b.ToTable("Alternativas");
                });

            modelBuilder.Entity("IBMYoung.Model.Boletim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AnoReferencia");

                    b.Property<int?>("AprendizId");

                    b.Property<DateTime>("DataCadastro");

                    b.Property<float>("Frequencia");

                    b.Property<string>("MesReferencia");

                    b.Property<float>("Nota");

                    b.Property<string>("Observacao");

                    b.HasKey("Id");

                    b.HasIndex("AprendizId");

                    b.ToTable("Boletins");
                });

            modelBuilder.Entity("IBMYoung.Model.Questao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Conteudo");

                    b.Property<int>("TarefaId");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("TarefaId");

                    b.ToTable("Questoes");
                });

            modelBuilder.Entity("IBMYoung.Model.Replica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Texto");

                    b.Property<int>("TopicoId");

                    b.HasKey("Id");

                    b.HasIndex("TopicoId");

                    b.ToTable("Replicas");
                });

            modelBuilder.Entity("IBMYoung.Model.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedName");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("IBMYoung.Model.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("IBMYoung.Model.Tarefa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Active");

                    b.Property<string>("Conteudo");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<DateTime>("DataExclusao");

                    b.Property<bool>("Entregavel");

                    b.Property<bool>("MultiEscolha");

                    b.Property<int>("Nivel");

                    b.Property<string>("Titulo");

                    b.Property<int>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tarefas");
                });

            modelBuilder.Entity("IBMYoung.Model.Topico", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Texto");

                    b.Property<string>("Titulo");

                    b.HasKey("Id");

                    b.ToTable("Topicos");
                });

            modelBuilder.Entity("IBMYoung.Model.User_Role", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId")
                        .HasAnnotation("SqlServer:Clustered", true);

                    b.ToTable("User_Roles");
                });

            modelBuilder.Entity("IBMYoung.Model.UserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("IBMYoung.Model.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nome");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PasswordSalt");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Sobrenome");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("IBMYoung.Model.Aprendiz", b =>
                {
                    b.HasBaseType("IBMYoung.Model.Usuario");

                    b.Property<DateTime>("DataEntrada");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DataNascimento");

                    b.Property<DateTime>("DataSaida");

                    b.Property<int?>("InstituicaoId");

                    b.Property<int>("Nivel");

                    b.Property<int?>("ResponsavelId");

                    b.HasIndex("InstituicaoId");

                    b.HasIndex("ResponsavelId");

                    b.ToTable("Aprendizes");

                    b.HasDiscriminator().HasValue("Aprendiz");
                });

            modelBuilder.Entity("IBMYoung.Model.Gestor", b =>
                {
                    b.HasBaseType("IBMYoung.Model.Usuario");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DataNascimento");

                    b.ToTable("Gestor");

                    b.HasDiscriminator().HasValue("Gestor");
                });

            modelBuilder.Entity("IBMYoung.Model.Instituicao", b =>
                {
                    b.HasBaseType("IBMYoung.Model.Usuario");

                    b.Property<DateTime>("DataFundacao");

                    b.ToTable("Instituicoes");

                    b.HasDiscriminator().HasValue("Instituicao");
                });

            modelBuilder.Entity("IBMYoung.Model.RecursosHumano", b =>
                {
                    b.HasBaseType("IBMYoung.Model.Usuario");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnName("DataNascimento");

                    b.ToTable("RecursosHumano");

                    b.HasDiscriminator().HasValue("RecursosHumano");
                });

            modelBuilder.Entity("IBMYoung.Model.Alternativa", b =>
                {
                    b.HasOne("IBMYoung.Model.Questao", "Questao")
                        .WithMany("Alternativas")
                        .HasForeignKey("QuestaoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IBMYoung.Model.Boletim", b =>
                {
                    b.HasOne("IBMYoung.Model.Aprendiz")
                        .WithMany("Boletins")
                        .HasForeignKey("AprendizId");
                });

            modelBuilder.Entity("IBMYoung.Model.Questao", b =>
                {
                    b.HasOne("IBMYoung.Model.Tarefa", "Tarefa")
                        .WithMany("Questoes")
                        .HasForeignKey("TarefaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IBMYoung.Model.Replica", b =>
                {
                    b.HasOne("IBMYoung.Model.Topico", "Topico")
                        .WithMany("Replicas")
                        .HasForeignKey("TopicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IBMYoung.Model.Tarefa", b =>
                {
                    b.HasOne("IBMYoung.Model.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IBMYoung.Model.Aprendiz", b =>
                {
                    b.HasOne("IBMYoung.Model.Instituicao", "Instituicao")
                        .WithMany("Aprendizes")
                        .HasForeignKey("InstituicaoId");

                    b.HasOne("IBMYoung.Model.Gestor", "Responsavel")
                        .WithMany("Aprendizes")
                        .HasForeignKey("ResponsavelId");
                });
#pragma warning restore 612, 618
        }
    }
}
