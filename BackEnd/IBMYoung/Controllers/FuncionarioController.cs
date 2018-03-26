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
    [Route("api/Funcionario")]
    public class FuncionarioController : Controller
    {
        ProjectContext _Db;
        public FuncionarioController(ProjectContext Db)
        {
            _Db = Db;

        }

        [HttpPost]
        public Funcionario Post([FromBody] FuncionarioCadastroViewModel model)
        {
            Funcionario funcionario = new Funcionario();
            

            _Db.Funcionarios.Add(funcionario);
            _Db.SaveChanges();

            return funcionario;
        }

        [HttpGet]
        public List<Funcionario> Get()
        {
            return _Db.Funcionarios.ToList();
        }
    }
}