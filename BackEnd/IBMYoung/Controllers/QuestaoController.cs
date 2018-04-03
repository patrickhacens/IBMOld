using System;
using System.Web;
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
    //[JWTAuth]
    [Produces("application/json")]
    [Route("api")]
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
        [Route("Questao/{tarefaId}")]
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
        [Route("Questao/{tarefaId}/{ordem}")]
        public async Task<Questao> Put(int tarefaId, int ordem, [FromBody] QuestaoCadastroViewModel model)
        {
            var questao = await db.Questoes
                .Include(d => d.Tarefa)
                .FirstOrDefaultAsync(d => d.TarefaId == tarefaId && d.Ordem == ordem);
            if (questao == null) throw new HttpException(404);

            questao.Conteudo = model.Conteudo;
            questao.Titulo = model.Titulo;

            await db.SaveChangesAsync();
            return questao;
        }

        /*
            End Point  utilizado pelo App Mobile na AlternativasActivity
         */
        [HttpGet]
        [Route("Questao/{tarefaId}/{ordem}")]
        public async Task<QuestaoViewModel> Get(int tarefaId, int ordem)
        {
            var result = await db.Questoes
                .Include(d => d.Alternativas)
                .FirstOrDefaultAsync(d => d.TarefaId == tarefaId && d.Ordem == ordem);
            if (result == null) throw new HttpException(404);
            else
            {
                return new QuestaoViewModel
                {
                    Ordem = result.Ordem,
                    Titulo = result.Titulo,
                    Conteudo = result.Conteudo,
                    TarefaId = result.TarefaId,
                    Alternativas = result.Alternativas
                        .OrderBy(f => Guid.NewGuid())
                        .Select(f => new AlternativaViewModel
                        {
                            Id = f.Id,
                            TextoAlternativa = f.TextoAlternativa,
                            Correta = f.Correta
                        }).ToList()
                };
            }
        }

        /*
            End Point  utilizado pelo App Mobile na QuestionariosActivity
         */
        [HttpGet]
        [Route("Questoes/{tarefaId}/{aprendizId}")]
        public List<QuestaoViewModel> GetList(int tarefaId, int aprendizId)
        {
            Aprendiz aprendiz = db.Aprendizes.OfType<Aprendiz>().FirstOrDefault(d => d.Id == aprendizId);
            List<QuestaoViewModel> lista = new List<QuestaoViewModel>();
            List<Questao> questoes = db.Questoes
                .Include(d => d.Respostas)
                .Where(d => d.TarefaId == tarefaId)
                .OrderBy(d => d.Ordem)
                .ToList();

            questoes.ForEach(d => lista.Add(new QuestaoViewModel
            {
                Ordem = d.Ordem,
                Titulo = d.Titulo,
                Conteudo = d.Conteudo,
                TarefaId = d.TarefaId,
                Respondida = d.Respostas.Any(r => r.Aprendiz == aprendiz)
            }));

            return lista;
        }


        [HttpPost]
        [Route("Questao/{tarefaId}/{ordem}/responder")]
        public async Task<IActionResult> Responder(int tarefaId, int ordem, [FromBody]  RespostaViewModel model)
        {
            Aprendiz aprendiz = db.Aprendizes
                .Include(a => a.Respostas)
                .SingleOrDefault(u => u.Id == model.AprendizId);
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

            Resposta resposta = new Resposta() {
                Aprendiz = aprendiz,
                AprendizId = aprendiz.Id,
                Questao = questao,
                TarefaId = tarefaId,
                Ordem = ordem,
                Alternativa = alternativa,
                AlternativaId = alternativa.Id
            };

            aprendiz.Respostas.Add(resposta);
            db.Respostas.Add(resposta);

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

            return Ok();
        }

    }
}