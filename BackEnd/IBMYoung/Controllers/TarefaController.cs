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
    [Route("api")]
    public class TarefaController : Controller
    {
        private readonly Db db;
        private readonly UserManager<Usuario> userManager;
        public TarefaController(Db db, UserManager<Usuario> userManager)
        {
            this.db = db;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<Tarefa> Post([FromBody] TarefaCadastroViewModel model)
        {
            Tarefa tarefa = new Tarefa()
            {
                Titulo = model.Titulo,
                Conteudo = model.Conteudo,
                Nivel = model.Nivel,
                DataCriacao = DateTime.Now,
                Active = true,
                Usuario = await userManager.GetUserAsync(this.User)
            };

            db.Tarefas.Add(tarefa);

            await db.SaveChangesAsync();

            return tarefa;
        }

        /// <summary>
        /// Retorna as tarefas criadas
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<IEnumerable<Tarefa>> Get() => await db.Tarefas.ToListAsync();

        /// <summary>
        /// Retorna a tarefa especifica
        /// </summary>
        /// <param name="id">id da tarefa</param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("{id}")]
        //public async Task<Tarefa> GetById(int id)
        //{
        //    var tarefa = await db.Tarefas
        //        .Include(d => d.Questoes)
        //        .Include(d => d.Usuario)
        //        .FirstOrDefaultAsync(d => d.Id == id);

        //    if (tarefa == null) throw new HttpException(404);

        //    return tarefa;
        //}

        /// <summary>
        /// Retorna a tarefa atual que o usuário esteja fazendo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Tarefa/current")]
        public async Task<TarefaViewModel> GetCurrent()
        {
            var aprendiz = await userManager.GetUserAsync(this.User) as Aprendiz;

            if (aprendiz == null) throw new HttpException(401, new { Message = "Não é um aprendiz" });

            var tarefa = await db.Tarefas
                .Include(d => d.Questoes)
                .ThenInclude(d => d.Respostas)
                .Include(d => d.Questoes)
                .ThenInclude(d => d.Alternativas)
                .Include(d => d.Usuario)
                .Where(d => d.Nivel >= aprendiz.Nivel)
                .Where(d => d.Questoes.Any(f => f.Respostas.All(g => g.Aprendiz != aprendiz)))
                .OrderBy(d => d.Nivel)
                .FirstOrDefaultAsync();
            if (tarefa == null) throw new HttpException(404, new { Message = "Nenhuma tarefa disponivel" });

            return new TarefaViewModel()
            {
                Nivel = tarefa.Nivel,
                Questoes = tarefa.Questoes.OrderBy(d => d.Ordem).Select(d => new QuestaoViewModel()
                {
                    TarefaId = tarefa.Id,
                    Titulo = d.Titulo,
                    Ordem = d.Ordem,
                    Respondida = d.Respostas.Any(g => g.Aprendiz == aprendiz),
                    Alternativas = d.Alternativas.OrderBy(f => Guid.NewGuid()).Select(f => new AlternativaViewModel()
                    {
                        TextoAlternativa = f.TextoAlternativa,
                        Id = f.Id
                    }).ToArray()
                }).ToArray()
            };
        }



        [HttpGet]
        [Route("Tarefas/{aprendizId}")]
        public async Task<List<TarefaAdapterViewModel>> GetById(int aprendizId)
        {
            Aprendiz aprendiz = db.Aprendizes.OfType<Aprendiz>().FirstOrDefault(d => d.Id == aprendizId);
            return await db.Tarefas
                .Include(d => d.Questoes)
                    .ThenInclude(d => d.Respostas)
                        .ThenInclude(d => d.Alternativa)
                .Where(d => d.Nivel >= aprendiz.Nivel)
                .OrderBy(d => d.Nivel)
                .OrderBy(d => d.DataCriacao)
                .Select(t => new TarefaAdapterViewModel {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Nivel = t.Nivel,
                    DataCriacao = t.DataCriacao,
                    Respondida = t.Questoes.All(q => q.Respostas.Any(r => r.Aprendiz == aprendiz)),
                    Correta = t.Questoes.All(q => q.Respostas.Where(r => r.Aprendiz == aprendiz).All(r => r.Alternativa.Correta))
                }).ToListAsync();
        }

        [HttpGet]
        [Route("Tarefas")]
        public List<TarefaAdapterViewModel> Get()
        {
            List<TarefaAdapterViewModel> lista = new List<TarefaAdapterViewModel>();
            db.Tarefas.ToList().ForEach(t => lista.Add(new TarefaAdapterViewModel
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Nivel = t.Nivel,
                DataCriacao = t.DataCriacao
            }));
            return lista;
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<Tarefa> Put(int id, TarefaCadastroViewModel model)
        {
            var tarefa = await db.Tarefas
                .FirstOrDefaultAsync(d => d.Id == id);
            if (tarefa == null) throw new HttpException(404);

            tarefa.Titulo = model.Titulo;
            tarefa.Conteudo = model.Conteudo;
            tarefa.Nivel = model.Nivel;
            tarefa.DataCriacao = DateTime.Now;
            tarefa.Active = true;
            tarefa.Usuario = await userManager.GetUserAsync(this.User);

            await db.SaveChangesAsync();

            return tarefa;
        }
    }
}