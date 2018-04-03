
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using IBMYoung.Infrastructure;
using IBMYoung.Infrastructure.ViewModel;
using IBMYoung.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace IBMYoung.Controllers
{
    [Produces("application/json")]
    [Route("api/Aprendiz")]
    [JWTAuth]
    public class AprendizController : Controller {
        private readonly Db db;
        private readonly Configuration config;
        private readonly UserManager<Usuario> userManager;
        public AprendizController(Db db, Configuration config, UserManager<Usuario> userManager) {
            this.db = db;
            this.config = config;
            this.userManager = userManager;
        }

        /*
            End Point utilizado pelo App Mobile na ClassificacaoActivity
        */
        [HttpGet]
        public List<AprendizViewModel> Get() {
            List<AprendizViewModel> lista = new List<AprendizViewModel>();
            db.Aprendizes.ToList().ForEach(aprendiz => lista.Add(new AprendizViewModel {
                Id = aprendiz.Id,
                Email = aprendiz.Email,
                Username = aprendiz.UserName,
                Nome = aprendiz.Nome,
                Sobrenome = aprendiz.Sobrenome,
                Nascimento = aprendiz.DataNascimento,
                Entrada = aprendiz.DataEntrada,
                Saida = aprendiz.DataSaida,
                Nivel = aprendiz.Nivel
            }));

            return lista;
        }

        /*
            End Point utilizado pelo App Mobile na ClassificacaoActivity
        */
        [HttpGet]
        [Route("{id}")]
        public  AprendizViewModel Aprendiz(int id) {
            Aprendiz aprendiz = db.Aprendizes.OfType<Aprendiz>().FirstOrDefault(d => d.Id == id);
            return new AprendizViewModel() {
                Id = aprendiz.Id,
                Email = aprendiz.Email,
                Username = aprendiz.UserName,
                Nome = aprendiz.Nome,
                Sobrenome = aprendiz.Sobrenome,
                Nascimento = aprendiz.DataNascimento,
                Entrada = aprendiz.DataEntrada,
                Saida = aprendiz.DataSaida,
                Nivel = aprendiz.Nivel
            };
        }

        [HttpPost]
        public async Task<Aprendiz> Post([FromBody]AprendizCadastroViewModel model)
        {
            Aprendiz aprendiz = default(Aprendiz);
            aprendiz = new Aprendiz(model.Nascimento, model.Entrada);

            aprendiz.Email = model.Email;
            aprendiz.SetPassword(model.Password);
            aprendiz.UserName = model.Username;
            aprendiz.Nome = model.Nome;
            aprendiz.Sobrenome = model.Sobrenome;

            db.Aprendizes.Add(aprendiz);
            await db.SaveChangesAsync();

            return aprendiz;
        }
    }
}