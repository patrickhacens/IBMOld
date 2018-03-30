
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
    [Route("api/[controller]")]
    [JWTAuth]
    public class AprendizController : Controller {
        private readonly Db db;
        private readonly Configuration config;
        private readonly UserManager<Aprendiz> userManager;
        public AprendizController(Db db, Configuration config, UserManager<Aprendiz> userManager) {
            this.db = db;
            this.config = config;
            this.userManager = userManager;
        }

        public class ClassificacaoViewModel {
            public string Username { get; set; }
            public int Nivel { get; set; }
        }

        [HttpGet]
        public List<Aprendiz> Get() {
            List<Aprendiz> lista = db.Aprendizes.ToList();

            return lista;
        }

        [HttpGet]
        [Route("{id}")]
        public  Aprendiz Aprendiz(int id) {
            return db.Aprendizes.OfType<Aprendiz>().FirstOrDefault(d => d.Id == id);
        }
    }
}