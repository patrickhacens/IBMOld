using IBMYoung.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        public DbSet<Instituicao> Instituicoes { get; set; }

        public DbSet<Questao> Questoes { get; set; }

        public DbSet<Alternativa> Alternativas { get; set; }

        public DbSet<Boletim> Boletins { get; set; }

        public DbSet<Topico> Topicos { get; set; }

        public DbSet<Replica> Replicas { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Aprendiz> Aprendizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Tarefa>().ToTable("Tarefas");
            modelBuilder.Entity<Instituicao>().ToTable("Instituicoes");
            modelBuilder.Entity<Questao>().ToTable("Questoes");
            modelBuilder.Entity<Alternativa>().ToTable("Alternativas");
            modelBuilder.Entity<Boletim>().ToTable("Boletins");
            modelBuilder.Entity<Topico>().ToTable("Topicos");
            modelBuilder.Entity<Replica>().ToTable("Replicas");
            modelBuilder.Entity<Funcionario>().ToTable("Funcionarios");
            modelBuilder.Entity<Aprendiz>().ToTable("Aprendizes");

            base.OnModelCreating(modelBuilder);
        }
        
    }
}
