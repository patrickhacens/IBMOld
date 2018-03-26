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
    [Route("api/Alternativa")]
    public class AlternativaController : Controller
    {
        Db _Db;

        public AlternativaController(Db Db)
        {
            _Db = Db;
        }

        [HttpPost]
        public Alternativa Post([FromBody] AlternativaCadastroViewModel model)
        {
            Alternativa alternativa = new Alternativa();

            alternativa.TextoAlternativa = model.AlternativaTexto;
            alternativa.Correta = model.Correta;

            _Db.Alternativas.Add(alternativa);
            _Db.SaveChanges();

            return alternativa;
        }
        [HttpGet]
        public List<Alternativa> Get()
        {
            return _Db.Alternativas.ToList();
        }
    }
}