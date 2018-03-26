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
    [Route("api/Topico")]
    public class TopicoController : Controller
    {
        Db _Db;
        public TopicoController(Db Db)
        {
            _Db = Db;
        }

        [HttpPost]
        public Topico Post([FromBody] TopicoCadastroViewModel model)
        {
            Topico topico = new Topico();
            model.Titulo = topico.Titulo;
            model.Texto = topico.Texto;
            topico.DataCriacao = DateTime.Now;

            _Db.Topicos.Add(topico);
            _Db.SaveChanges();

            return topico;
        }

        [HttpGet]
        public List<Topico> Get()
        {
            return _Db.Topicos.ToList();
        }
    }
}