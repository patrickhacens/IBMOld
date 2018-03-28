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
    }
}