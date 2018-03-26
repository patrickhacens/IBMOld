using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBMYoung.Infrastructure;
using IBMYoung.Infrastructure.ViewModel;
using IBMYoung.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IBMYoung.Controllers
{
    [Produces("application/json")]
    [Route("api/Tarefa")]
    public class TarefaController : Controller
    {
        Db _Db;
        public TarefaController(Db Db)
        {
            _Db = Db;

        }

        [HttpPost]
        public Tarefa Post([FromBody] TarefaCadastroViewModel model)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Titulo = model.titulo;
            tarefa.Conteudo = model.conteudo;
            tarefa.Entregavel = model.entregavel;
            tarefa.Nivel = model.nivel;
            tarefa.DataCriacao = DateTime.Now;
            tarefa.Active = true;

            _Db.Tarefas.Add(tarefa);
            _Db.SaveChanges();

            return tarefa;
        }

        [HttpGet]
        public List<Tarefa> Get()
        {
            return _Db.Tarefas.ToList();
        }

    }
}