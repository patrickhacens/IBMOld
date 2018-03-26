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
    [Route("api/Questao")]
    public class QuestaoController : Controller
    {
        ProjectContext _Db;

        public QuestaoController(ProjectContext Db)
        {
            _Db = Db;
        }

        [HttpPost]
        public Questao Post([FromBody] QuestaoCadastroViewModel model)
        {
            Questao questao = new Questao();
            questao.Titulo = model.titulo;
            questao.Conteudo = model.conteudo;

            _Db.Questoes.Add(questao);
            _Db.SaveChanges();

            return questao;
        }

        [HttpGet]
        public List<Questao> Get()
        {
            return _Db.Questoes.ToList();
        }
    }
}