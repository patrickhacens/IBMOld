using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBMYoung.Infrastructure;
using IBMYoung.Infrastructure.ViewModel;
using IBMYoung.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBMYoung.Controllers
{
    [JWTAuth]
    [Produces("application/json")]
    [Route("api/Questao")]
    public class QuestaoController : Controller
    {
        private readonly Db db;
        private readonly UserManager<Usuario> userManager;

        public QuestaoController(Db db, UserManager<Usuario> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("/api/tarefa/{tarefaId}")]
        public async Task<Questao> Post(int tarefaId, [FromBody] QuestaoCadastroViewModel model)
        {
            var tarefa = await db.Tarefas
                .Include(d => d.Questoes)
                .FirstOrDefaultAsync(d => d.Id == tarefaId);

            if (tarefa == null) throw new HttpException(404);

            var questao = new Questao()
            {
                Conteudo = model.Conteudo,
                Ordem = model.Ordem,
                Titulo = model.Titulo,
                Tarefa = tarefa
            };

            tarefa.Questoes.Add(questao);

            await db.SaveChangesAsync();

            return questao;
        }

        [HttpPut]
        [Route("{tarefaId}/{ordem}")]
        public async Task<Questao> Put(int tarefaId, int ordem, [FromBody] QuestaoCadastroViewModel model)
        {
            var questao = await db.Questoes
                .Include(d => d.Tarefa)
                .FirstOrDefaultAsync(d => d.TarefaId == tarefaId && ordem == ordem);
            if (questao == null) throw new HttpException(404);

            questao.Conteudo = model.Conteudo;
            questao.Titulo = model.Titulo;

            await db.SaveChangesAsync();
            return questao;
        }

        [HttpGet]
        [Route("{tarefaId}/{ordem}")]
        public async Task<Questao> Get(int tarefaId, int ordem)
        {
            var result = await db.Questoes
                .Include(d => d.Alternativas)
                .FirstOrDefaultAsync(d => d.TarefaId == tarefaId && ordem == ordem);
            if (result == null) throw new HttpException(404);
            return result;
        }


        public class RespostaViewModel
        {
            public int AlternativaId { get; set; }
        }

        public class RespostaRetornoViewModel
        {
            public int AlternativaId { get; set; }

            public bool Correta { get; set; }

            public int Nivel { get; set; }

            public bool LastAnswer { get; set; }
        }

        [HttpGet]
        [Route("{tarefaId}/{ordem}/responder")]
        public async Task<RespostaRetornoViewModel> Responder(int tarefaId, int ordem, [FromBody] RespostaViewModel model)
        {
            var aprendiz = await userManager.GetUserAsync(this.User) as Aprendiz;
            if (aprendiz == null) throw new HttpException(401, new { Mensagem = "Não é aprendiz" });

            Questao questao = await db.Questoes
                .Include(d => d.Alternativas)
                .Include(d => d.Respostas)
                .Include(d => d.Tarefa)
                .FirstOrDefaultAsync(d => d.TarefaId == tarefaId && d.Ordem == ordem);

            if (questao.Respostas.Any(d => d.Aprendiz == aprendiz))
                throw new HttpException(401, new { Mensagem = "Já respondido" });

            if (questao == null)
                throw new HttpException(404, new { Mensagem = "Questao não encontrada" });

            var alternativa = questao.Alternativas.FirstOrDefault(d => d.Id == model.AlternativaId);

            if (alternativa == null)
                throw new HttpException(404, new { Mensagem = "Alternativa não encontrada" });

            aprendiz.Respostas.Add(new Resposta()
            {
                Alternativa = alternativa,
                Questao = questao
            });

            bool isLastAnswer = await db.Tarefas
                .Include(t => t.Questoes)
                .ThenInclude(q => q.Respostas)
                .Where(t => t.Id == tarefaId)
                .Where(t => t.Questoes.All(q => q.Respostas.Any(r => r.Aprendiz == aprendiz)))
                .AnyAsync();

            // verify if finished answering
            if (isLastAnswer)
            {
                var tarefa = await db.Tarefas.Include(t => t.Questoes).ThenInclude(q => q.Respostas).FirstOrDefaultAsync(t => t.Id == tarefaId);
                if (tarefa.Questoes
                    .All(q => q.Respostas
                        .Where(r => r.Aprendiz == aprendiz)
                        .All(r => r.Alternativa.Correta)))
                {
                    aprendiz.Nivel = Math.Max(aprendiz.Nivel, questao.Tarefa.Nivel);
                }
            }

            await db.SaveChangesAsync();

            return new RespostaRetornoViewModel()
            {
                AlternativaId = alternativa.Id,
                Correta = alternativa.Correta,
                Nivel = aprendiz.Nivel,
                LastAnswer = isLastAnswer,
            };
        }
    }
}