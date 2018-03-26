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
    [Route("api/Instituicao")]
    public class InstituicaoController : Controller
    {
        ProjectContext _Db;
        public InstituicaoController(ProjectContext Db)
        {
            _Db = Db;
        }

        [HttpPost]
        public Instituicao Post([FromBody] InstituicaoCadastroViewModel model)
        {
            Instituicao instituicao = new Instituicao();
            instituicao.Nome = model.nome;

            _Db.Instituicoes.Add(instituicao);
            _Db.SaveChanges();

            return instituicao;
        }

        [HttpGet]
        public List<Instituicao> Get()
        {
            return _Db.Instituicoes.ToList();
        }
    }
}