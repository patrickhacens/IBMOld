using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBMYoung.Infrastructure;
using IBMYoung.Infrastructure.ViewModel;
using IBMYoung.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IBMYoung.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    public class TopicoController : Controller
    {
        Db _Db;
        public TopicoController(Db Db)
        {
            _Db = Db;
        }

        [HttpPost]
        [Route("topicos")]
        public Topico Post([FromBody] TopicoCadastroViewModel model)
        {
            Topico topico = new Topico();
            topico.Titulo = model.Titulo;
            topico.Texto = model.Texto;
            topico.DataCriacao = DateTime.Now;
            topico.Usuario = _Db.Usuarios.First();

            _Db.Topicos.Add(topico);
            _Db.SaveChanges();

            return topico;
        }

        [HttpGet]
        [Route("topicos")]
        public List<Topico> Get()
        {
            return _Db.Topicos.Include(a => a.Replicas.Select(b => b.Usuario)).Include(a => a.Usuario).ToList();
        }
    }
}