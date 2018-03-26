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
    [Route("api/Aprendiz")]
    public class AprendizController : Controller
    {
        Db _Db;
        public AprendizController(Db Db)
        {
            _Db = Db;
        }

        [HttpPost]
        public Aprendiz Post([FromBody] AprendizCadastroViewModel model)
        {

            Aprendiz aprendiz = new Aprendiz();
            aprendiz.Nome = model.Nome;
            aprendiz.Sobrenome = model.Sobrenome;
            aprendiz.Instituicao = model.Instituicao;
            aprendiz.DataEntrada = model.DataEntrada;


            _Db.Aprendizes.Add(aprendiz);
            _Db.SaveChanges();

            return aprendiz;
        }

        [HttpGet]
        public List<Aprendiz> Get()
        {
            return _Db.Aprendizes.ToList();
        }

    }
}