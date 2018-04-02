using IBMYoung.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IBMYoung.Infrastructure {
    public static class DbSeeder {
        public static async Task Seed(Db db) {
            await ClearDb(db);

            var user1 = new RecursosHumano() {
                Nome = "Patrick",
                Email = "patrick@gmail.com",
                Sobrenome = "Ens",
                DataNascimento = DateTime.Now
            };
            user1.SetPassword("teste1234%");
            db.Usuarios.Add(user1);

            var gestor1 = new Gestor() {
                Nome = "gestor",
                Email = "gestor@gmail.com",
                Sobrenome = "gestão",
                DataNascimento = DateTime.Now,
            };
            gestor1.SetPassword("teste1234%");
            db.Usuarios.Add(gestor1);

            var inst1 = new Instituicao() {
                Nome = "instituicao",
                Email = "inst@gmail.com",
                Sobrenome = "insti",
                DataFundacao = DateTime.Now,
            };
            inst1.SetPassword("teste1234%");
            db.Usuarios.Add(inst1);

            var aprendiz1 = new Aprendiz(DateTime.Now, DateTime.Now, DateTime.Now.AddDays(90), inst1, gestor1) {
                Nome = "Antonio",
                UserName = "adealmeida",
                Sobrenome = "de Almeida",
                Email = "adealmeida@gmail.com",
                Nivel = 0
            };
            aprendiz1.SetPassword("teste$132");
            db.Usuarios.Add(aprendiz1);

            var aprendiz2 = new Aprendiz(DateTime.Now, DateTime.Now, DateTime.Now.AddDays(40), inst1, gestor1) {
                Nome = "José",
                UserName = "jcamargo",
                Sobrenome = "Lima Camargo",
                Email = "jcamargo@hotmail.com",
                Nivel = 2
            };
            aprendiz2.SetPassword("novo$132");
            db.Usuarios.Add(aprendiz2);

            var tarefa1 = new Tarefa() {
                Active = true,
                Conteudo = "Conhecimento da Lingua Inglêsa",
                DataCriacao = DateTime.Now,
                Nivel = 1,
                Titulo = "Atividade de Ingles - Tradução",
                Usuario = user1,
                Questoes = new List<Questao>() {
                            new Questao() {
                                Titulo = "Selecione a alternativa correta",
                                Ordem = 1,
                                Conteudo = "What does business mean?",
                                Alternativas = new List<Alternativa>() {
                                    new Alternativa() {
                                        TextoAlternativa = "Necogiação",
                                        Correta = false,
                                    },
                                    new Alternativa() {
                                        TextoAlternativa = "Negócio",
                                        Correta = true,
                                    },
                                    new Alternativa() {
                                        TextoAlternativa = "Empresa",
                                        Correta = false,
                                    },
                                    new Alternativa() {
                                        TextoAlternativa = "Nenhuma das anteriores",
                                        Correta = false,
                                    },
                                }
                            },
                            new Questao() {
                                Titulo = "Qual a correta tradução",
                                Ordem = 2,
                                Conteudo = "Google bans Chrome extensions",
                                    Alternativas = new List<Alternativa>() {
                                      new Alternativa() {
                                           TextoAlternativa = "Google impede as extensões do Chrome",
                                           Correta = false,
                                      },
                                      new Alternativa() {
                                           TextoAlternativa = "Google impele o Chrome e extensões",
                                           Correta = false,
                                      },
                                      new Alternativa() {
                                           TextoAlternativa = "Google proíbe extensões do Chrome",
                                           Correta = true,
                                      },
                                      new Alternativa() {
                                           TextoAlternativa = "Google maldiz as extensões do Chrome ",
                                           Correta = false,
                                      },
                                  }
                            }
                      }
            };
            db.Tarefas.Add(tarefa1);

            var tarefa2 = new Tarefa() {
                Active = true,
                Conteudo = "Conhecimento da Lingua Inglêsa",
                DataCriacao = DateTime.Now,
                Nivel = 2,
                Titulo = "Atividade de Ingles - Significado",
                Usuario = user1,
                Questoes = new List<Questao>() {
                            new Questao() {
                                Titulo = "Sobre o que é discutido",
                                Ordem = 1,
                                Conteudo = "As it pushes beyond the tech industry, artiticial intelligence could make workplaces fairer - os more oppressive",
                                Alternativas = new List<Alternativa>() {
                                    new Alternativa() {
                                        TextoAlternativa = "Como as pessoas trabalham",
                                        Correta = false,
                                    },
                                    new Alternativa() {
                                        TextoAlternativa = "Como funciona as empresas",
                                        Correta = false,
                                    },
                                    new Alternativa() {
                                        TextoAlternativa = "A influência da IA no trabalho",
                                        Correta = true,
                                    },
                                    new Alternativa() {
                                        TextoAlternativa = "Nenhuma das anteriores",
                                        Correta = false,
                                    },
                                }
                            },
                            new Questao() {
                                Titulo = "Qual o sujeito na frase",
                                Ordem = 2,
                                Conteudo = "Accusations against a moderate presidential candidate could hand power to a left-wing populist",
                                    Alternativas = new List<Alternativa>() {
                                      new Alternativa() {
                                           TextoAlternativa = "Presidente Populista",
                                           Correta = false,
                                      },
                                      new Alternativa() {
                                           TextoAlternativa = "Populista de esquerda",
                                           Correta = false,
                                      },
                                      new Alternativa() {
                                           TextoAlternativa = "Moderado Populista",
                                           Correta = false,
                                      },
                                      new Alternativa() {
                                           TextoAlternativa = "Candidato Presidencial",
                                           Correta = true,
                                      },
                                  }
                            }
                      }
            };
            db.Tarefas.Add(tarefa2);

            var topico = new Topico {
                Titulo = "Qual o melhor database?",
                Texto = "Qual o melhor database, MongoDB ou Firebase?",
                DataCriacao = DateTime.Now.AddDays(30),
                Usuario = aprendiz1,
                Replicas = new List<Replica>() {
                    new Replica() {
                        Texto = "Para Startups com projetos pequenos acredito que Firebase",
                        DataCriacao = DateTime.Now.AddDays(31),
                        Usuario = aprendiz2
                    },
                    new Replica() {
                        Texto = "Eu acreditava que seria o Mongo...",
                        DataCriacao = DateTime.Now.AddDays(33),
                        Usuario = aprendiz1
                    }
                }
            };
            db.Topicos.Add(topico);

            await db.SaveChangesAsync();
        }

        private static async Task ClearDb(Db db) {
            db.Replicas.RemoveRange(db.Replicas.ToArray());
            db.Topicos.RemoveRange(db.Topicos.ToArray());
            db.Alternativas.RemoveRange(db.Alternativas.ToArray());
            db.Questoes.RemoveRange(db.Questoes.ToArray());
            db.Tarefas.RemoveRange(db.Tarefas.ToArray());
            db.Usuarios.RemoveRange(db.Usuarios.ToArray());
            await db.SaveChangesAsync();
        }
    }
}
