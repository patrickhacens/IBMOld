using IBMYoung.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {  }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Instituicao> Instituicoes { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        public DbSet<Alternativa> Alternativas { get; set; }
        public DbSet<Boletim> Boletins { get; set; }
        public DbSet<Topico> Topicos { get; set; }
        public DbSet<Replica> Replicas { get; set; }
        public DbSet<RoleClaim> RoleClaims { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User_Role> User_Roles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<Aprendiz> Aprendizes { get; set; }

        protected override void OnModelCreating(ModelBuilder m)
        {
            m.Entity<Usuario>().ToTable("Usuarios");
            m.Entity<Tarefa>().ToTable("Tarefas");
            m.Entity<Instituicao>().ToTable("Instituicoes");
            m.Entity<Questao>().ToTable("Questoes");
            m.Entity<Alternativa>().ToTable("Alternativas");
            m.Entity<Boletim>().ToTable("Boletins");
            m.Entity<Topico>().ToTable("Topicos");
            m.Entity<Replica>().ToTable("Replicas");
            m.Entity<Aprendiz>().ToTable("Apredizes");

            m.Entity<RecursosHumano>();
            m.Entity<Aprendiz>();
            m.Entity<Gestor>();
            m.Entity<Instituicao>();

            m.Entity<User_Role>().HasKey(r => new { r.UserId, r.RoleId }).ForSqlServerIsClustered(true);

            m.Entity<Questao>().HasKey(r => new { r.TarefaId, r.Ordem }).ForSqlServerIsClustered(true);

            m.Entity<Resposta>().HasKey(r => new { r.AprendizId, r.TarefaId, r.Ordem }).ForSqlServerIsClustered(true);

            
            base.OnModelCreating(m);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }
    }
}
