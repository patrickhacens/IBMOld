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
    [Route("api/[controller]")]
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

        [HttpGet]
        public async Task<IEnumerable<Tarefa>> Get() => await db.Tarefas.ToListAsync();


        [HttpGet]
        [Route("{id}")]
        public async Task<Tarefa> GetById(int id)
        {
            var tarefa = await db.Tarefas
                .Include(d => d.Questoes)
                .Include(d => d.Usuario)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (tarefa == null) throw new HttpException(404);

            return tarefa;
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