using IBMYoung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure
{
    public static class DbSeeder
    {
        public static async Task Seed(Db db)
        {

            await ClearDb(db);

            var user1 = new RecursosHumano()
            {
                Nome = "Patrick",
                Email = "patrick@gmail.com",
                Sobrenome = "Ens",
                DataNascimento = DateTime.Now
            };
            user1.SetPassword("teste1234%");
            db.Usuarios.Add(user1);


            var gestor1 = new Gestor()
            {
                Nome = "gestor",
                Email = "gestor@gmail.com",
                Sobrenome = "gestão",
                DataNascimento = DateTime.Now,
            };
            gestor1.SetPassword("teste1234%");
            db.Usuarios.Add(gestor1);

            var inst1 = new Instituicao()
            {
                Nome = "instituicao",
                Email = "inst@gmail.com",
                Sobrenome = "insti",
                DataFundacao = DateTime.Now,
            };
            inst1.SetPassword("teste1234%");
            db.Usuarios.Add(inst1);

            var aprendiz1 = new Aprendiz(DateTime.Now, DateTime.Now, DateTime.Now.AddDays(90), inst1, gestor1)
            {
                Nome = "aprendiz",
                UserName = "aprendiz",
                Sobrenome = "a",
                Email = "aprendiz@gmail.com",
            };
            aprendiz1.SetPassword("teste1234%");
            db.Usuarios.Add(aprendiz1);

            var tarefa = new Tarefa()
            {
                Active = true,
                Conteudo = "Tarefa 1",
                DataCriacao = DateTime.Now,
                Nivel = 1,
                Titulo = "Tarefa 1",
                Usuario = user1,
                Questoes = new List<Questao>()
                      {
                          new Questao()
                          {
                               Titulo = "Questao 1",
                                Ordem = 1,
                                 Conteudo = "Questao 1",
                                  Alternativas = new List<Alternativa>()
                                  {
                                      new Alternativa()
                                      {
                                           TextoAlternativa = "Alternativa 1",
                                           Correta = false,
                                      },
                                      new Alternativa()
                                      {
                                           TextoAlternativa = "Alternativa Correta",
                                           Correta = true,
                                      },
                                      new Alternativa()
                                      {
                                           TextoAlternativa = "Alternativa 3",
                                           Correta = false,
                                      },
                                      new Alternativa()
                                      {
                                           TextoAlternativa = "Alternativa 4",
                                           Correta = false,
                                      },
                                  }
                          },
                          new Questao()
                          {
                               Titulo = "Questao 2",
                                Ordem = 2,
                                 Conteudo = "Questao 2",
                                  Alternativas = new List<Alternativa>()
                                  {
                                      new Alternativa()
                                      {
                                           TextoAlternativa = "Alternativa 1",
                                           Correta = false,
                                      },
                                      new Alternativa()
                                      {
                                           TextoAlternativa = "Alternativa 2",
                                           Correta = false,
                                      },
                                      new Alternativa()
                                      {
                                           TextoAlternativa = "Alternativa Correta",
                                           Correta = true,
                                      },
                                      new Alternativa()
                                      {
                                           TextoAlternativa = "Alternativa 4",
                                           Correta = false,
                                      },
                                  }
                          }
                      }
            };

            db.Tarefas.Add(tarefa);

            await db.SaveChangesAsync();
        }

        private static async Task ClearDb(Db db)
        {
            db.Usuarios.RemoveRange(db.Usuarios.ToArray());
            db.Tarefas.RemoveRange(db.Tarefas.ToArray());
            await db.SaveChangesAsync();
        }
    }
}
