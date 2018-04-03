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

namespace IBMYoung.Controllers {
    //[JWTAuth]
    [Produces("application/json")]
    [Route("api")]
    public class TarefaController : Controller {
        private readonly Db db;
        private readonly UserManager<Usuario> userManager;
        public TarefaController(Db db, UserManager<Usuario> userManager) {
            this.db = db;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Tarefa")]
        public async Task<Tarefa> Post([FromBody] TarefaCadastroViewModel model) {
            Tarefa tarefa = new Tarefa() {
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

        /*
            End Point utilizado pelo App Mobile na TarefasActivity
         */
        [HttpGet]
        [Route("Tarefas/{aprendizId}")]
        public List<TarefaAdapterViewModel> Get(int aprendizId) {
            Aprendiz aprendiz = db.Aprendizes.OfType<Aprendiz>().FirstOrDefault(d => d.Id == aprendizId);
            List<TarefaAdapterViewModel> lista = new List<TarefaAdapterViewModel>();
            db.Tarefas
                .Include(d => d.Questoes)
                .ThenInclude(d => d.Respostas)
                .Where(d => d.Nivel >= aprendiz.Nivel)
                .OrderBy(d => d.Nivel)
                .OrderBy(d => d.DataCriacao)
                .ToList().ForEach(t => lista.Add(new TarefaAdapterViewModel {
                    Id = t.Id,
                    Titulo = t.Titulo,
                    Nivel = t.Nivel,
                    DataCriacao = t.DataCriacao,
                    Respondida = t.Questoes.All(q => q.Respostas.Any(r => r.Aprendiz == aprendiz))
            }));
            return lista;
        } 

        [HttpGet]
        [Route("Tarefas")]
        public List<TarefaAdapterViewModel> Get() {
            List<TarefaAdapterViewModel> lista = new List<TarefaAdapterViewModel>();
            db.Tarefas.ToList().ForEach(t => lista.Add(new TarefaAdapterViewModel {
                Id = t.Id,
                Titulo = t.Titulo,
                Nivel = t.Nivel,
                DataCriacao = t.DataCriacao
            }));
            return lista;
        } 



        [HttpPut]
        [Route("{id}")]
        public async Task<Tarefa> Put(int id, TarefaCadastroViewModel model) {
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